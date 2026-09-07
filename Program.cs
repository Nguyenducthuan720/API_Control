using APISmartCity;
using APISmartCity.DI;
using APISmartCity.GoogleTranslateServices;
using APISmartCity.Helpers;
using APISmartCity.ISAPIServices;
using APISmartCity.lib;
using APISmartCity.Lib.Function;
using APISmartCity.MQTTServices;
using APISmartCity.Services;
using APISmartCity.TransferDataPostgreSQLServices;
using APISmartCity.TransferServices;
using APISmartCity.VietmapGeocodeServices;
using DMS.Controllers.Sockets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using StaticService;
using System.Text;
using System.Globalization;
using DMS.Lib.Files;

var builder = WebApplication.CreateBuilder(args);

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

Global.ApiKey = builder.Configuration.GetConnectionString("SignalrAPIKEY");
Global.VietMapApiKey = builder.Configuration.GetConnectionString("VietMapApiKey");
Global.VietMapVehicle = builder.Configuration.GetConnectionString("VietMapVehicle");
Global.connectString = builder.Configuration.GetConnectionString("ConfigConnection").DecryptData();

if(builder.Configuration.GetConnectionString("ConfigConnectionPostgreSQL") != null)
{
    Global.connectStringPostgreSQL = builder.Configuration.GetConnectionString("ConfigConnectionPostgreSQL").DecryptData();
}

Global.RunAPIShare = builder.Configuration.GetConnectionString("RunAPIShare");

Global.MQTTAddress = builder.Configuration.GetValue<string>("MQTT:Address");
Global.MQTTUser = builder.Configuration["MQTT:User"].DecryptData();
Global.MQTTPassword = builder.Configuration["MQTT:Password"].DecryptData();

Global.DCPassword = builder.Configuration["UserDomain:DCPassword"].DecryptData();
Global.DCUserName = builder.Configuration["UserDomain:DCUserName"];
Global.BaseDN = builder.Configuration["UserDomain:BaseDN"];
Global.DCPort = builder.Configuration["UserDomain:DCPort"];
Global.DCServer = builder.Configuration["UserDomain:DCServer"];
Global.IsUserDomain = builder.Configuration["UserDomain:IsUserDomain"];

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = false);
builder.Services.Configure<KestrelServerOptions>(options => options.Limits.MaxRequestBodySize = int.MaxValue);
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
});
builder.Services.AddControllers(options => options.Filters.Add(new ProducesAttribute("application/json")))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddSwaggerDocumentation();
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpClient();
builder.Services.AddScoped<UserInfo>();
builder.Services.AddScoped<APIInfo>();
builder.Services.AddScoped<ISAPIService>();
builder.Services.AddScoped<WordToPdfService>();
builder.Services.AddScoped<ExcelToPdfService>();
builder.Services.AddSingleton<HandlebarsHtmlRenderer>();
builder.Services.AddScoped<NLTShipping.Export.FileHTML>();
builder.Services.AddSingleton<GoogleTranslateService>();
builder.Services.AddSingleton<VietmapGeocodeService>();
builder.Services.AddSingleton<TransferService>();
builder.Services.AddSingleton<TransferDataDeviceService>();
builder.Services.AddSingleton<TransferDataPostgreSQLService>();
builder.Services.AddSingleton<KimTinService>();
builder.Services.AddSingleton<MQTTService>();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IConverter>(
    _ => new SynchronizedConverter(new PdfTools()));
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", x => x.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((_) => true).AllowCredentials()));
builder.Services.AddSignalR(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(15); // Thời gian giữ kết nối
});
//builder.Services.AddResponseCompression(options =>
//{
//    options.EnableForHttps = true;
//});
var app = builder.Build();
app.UseHttpsRedirection();
StaticServiceProvider.Provider = app.Services;
MQTTService mqtt = (MQTTService)StaticServiceProvider.Provider!.GetService(typeof(MQTTService))!;
mqtt.RunAsync().GetAwaiter().GetResult();

// 🔥 SET LẠI CULTURE SAU KHI MQTT CHẠY
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

Init.IntDB();
app.UseCors("CorsPolicy");
//app.UseResponseCompression();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware();
app.UseSwaggerDocumentation();
app.MapControllers();

//thêm signalr
app.UseWebSockets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chathub");
});
app.Run();

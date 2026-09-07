using APISmartCity.lib;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace APISmartCity.Helpers
{
    public static class SwaggerDocumentation
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                if (Global.RunAPIShare == "0")
                {
                    c.SwaggerDoc("SmartCity", new OpenApiInfo { Title = "Main", Version = "v2" });
                    c.SwaggerDoc("Guests", new OpenApiInfo { Title = "không cần xác thực", Version = "v2" });
                    c.SwaggerDoc("Init", new OpenApiInfo { Title = "Xác thực và cấu hình", Version = "v2" });
                    c.SwaggerDoc("Category", new OpenApiInfo { Title = "Danh mục/Chức năng dùng chung", Version = "v2" });
                    c.SwaggerDoc("Functions", new OpenApiInfo { Title = "Chức năng nghiệp vụ", Version = "v2" });
                    c.SwaggerDoc("nPL", new OpenApiInfo { Title = "nPL", Version = "v2" });
                    c.SwaggerDoc("Notification", new OpenApiInfo { Title = "Thông báo", Version = "v2" });
                    c.SwaggerDoc("Sync", new OpenApiInfo { Title = "Đồng bộ dữ liệu server", Version = "v2" });
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}/{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                    c.CustomSchemaIds(type => type.ToString().Replace("+", "."));
                    c.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            Description = "JWT Authorization header using the Bearer scheme.",
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer"
                        });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });

                    //API Key
                    c.AddSecurityDefinition("ApiKey",
                        new OpenApiSecurityScheme()
                        {
                            Name = "APIKEY",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                            Description = "Authorization by x-api-key inside request's header",
                            Scheme = "ApiKeyScheme"
                        });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference{
                                    Id = "ApiKey",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });

                    c.OperationFilter<AddRequiredHeaderParameter>();
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                    //c.EnableAnnotations();
                    c.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        switch (docName)
                        {
                            case "SmartCity":
                                return apiDesc.GroupName.Contains("Microservice");

                            case "Guests":
                                return apiDesc.GroupName.Contains("Guests");

                            case "Category":
                                return apiDesc.GroupName.Contains("Microservice.Category");

                            case "Init":
                                return apiDesc.GroupName.Contains("Microservice.Init");

                            case "Functions":
                                return apiDesc.GroupName.Contains("Functions");

                            case "nPL":
                                return apiDesc.GroupName.Contains("nPL");

                            case "Notification":
                                return apiDesc.GroupName.Contains("Notification");

                        }
                        return false;
                    });
                    c.TagActionsBy(api => new List<string> { api.GroupName });
                    c.ExampleFilters();
                }
                else
                {
                    c.SwaggerDoc("ShareData", new OpenApiInfo { Title = "Chia sẽ dữ liệu hệ thống DMS", Version = "v2" });
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}/{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                    c.CustomSchemaIds(type => type.ToString().Replace("+", "."));
                    c.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            Description = "JWT Authorization header using the Bearer scheme.",
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer"
                        });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });

                    c.OperationFilter<AddRequiredHeaderParameter>();
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                    //c.EnableAnnotations();
                    c.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        switch (docName)
                        {
                            case "ShareData":
                                return apiDesc.GroupName.Contains("Microservice.ShareData");
                        }
                        return false;
                    });
                    c.TagActionsBy(api => new List<string> { api.GroupName });
                    c.ExampleFilters();
                }


            });
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                if (Global.RunAPIShare == "0")
                {
                    c.SwaggerEndpoint("/swagger/Init/swagger.json", "01.Init");
                    c.SwaggerEndpoint("/swagger/Category/swagger.json", "02.Category");
                    c.SwaggerEndpoint("/swagger/Functions/swagger.json", "03.Functions");
                    c.SwaggerEndpoint("/swagger/nPL/swagger.json", "04.nPL");
                    c.SwaggerEndpoint("/swagger/Guests/swagger.json", "05.Guests");
                    c.SwaggerEndpoint("/swagger/SmartCity/swagger.json", "09.FullAPI");
                }
                else
                {
                    c.SwaggerEndpoint("/swagger/ShareData/swagger.json", "ShareData");
                }


                c.DisplayRequestDuration();
                c.DefaultModelsExpandDepth(-1);
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Example);
                c.EnableTryItOutByDefault();
                c.DocExpansion(DocExpansion.None);
                //c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
            });

            return app;
        }
    }
}
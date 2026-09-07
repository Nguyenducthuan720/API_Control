using APISmartCity.lib;
using MQTTnet;
using MQTTnet.Client;
using System.Security.Authentication;

namespace APISmartCity.MQTTServices
{
    public class MQTTService
    {
        private IMqttClient _mqttClient { get; set; }
        private MqttFactory _mqttFactory { get; set; }

        public async Task RunAsync()
        {
            try
            {
                _mqttFactory = new MqttFactory();

                _mqttClient = _mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder()
                        .WithWebSocketServer(o => o.WithUri(Global.MQTTAddress))
                        .WithTlsOptions(x => { x.UseTls(); x.WithSslProtocols(SslProtocols.Tls12); })
                        .WithCredentials(Global.MQTTUser, Global.MQTTPassword)
                        .WithCleanStart(true)
                        .WithSessionExpiryInterval(3600)
                        .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                        .Build();

                await _mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StopAsync()
        {
            try
            {
                await _mqttClient.DisconnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<bool> PublishAsync(string StationID, string payload)
        {
            try
            {
                if (!_mqttClient.IsConnected)
                {
                    await RunAsync();
                }
                var applicationMessage = new MqttApplicationMessageBuilder()
                            .WithTopic($"Ver2/NLT7004/FE/SmartTraffic/{StationID}/Control")
                            .WithPayload(payload)
                            .Build();

                var result = await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
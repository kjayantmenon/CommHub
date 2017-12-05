

namespace NotificationsHub.Channels
{
    using System.Threading.Tasks;
    using NotificationsHub.Contracts;
    using NotificationsHub.Models;
    
    using Newtonsoft.Json;
    using Microsoft.Azure.NotificationHubs;
    using Serilog;

    public class NotificationHubChannel : IChannel
    {
        NotificationHubClient hub = null;
        public NotificationHubChannel()
        {
            var hubConnString = "Endpoint=sb://namespacej1.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ubTlaQ6s7A8ulN8OIkYHmRKyIG+FsbE3ALEQ04Bg4Ec=";
            var hubName = "mytestnh";
            hub = NotificationHubClient.CreateClientFromConnectionString(hubConnString, hubName);
        }
        ILogger _logger = null;
        public NotificationHubChannel(ILogger logger)
        {
            _logger = logger;

            var hubConnString = "Endpoint=sb://namespacej1.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ubTlaQ6s7A8ulN8OIkYHmRKyIG+FsbE3ALEQ04Bg4Ec=";
            var hubName = "mytestnh";
            hub = NotificationHubClient.CreateClientFromConnectionString(hubConnString, hubName);
        }

        public async Task Send(Message message, string ActivityId="")
        {
            _logger.Information($"ActivityId {ActivityId} :Sending notification {message.id} {message.to}....");
            string msgString = JsonConvert.SerializeObject(message);
            await hub.SendGcmNativeNotificationAsync(msgString);
            _logger.Information($"ActivityId {ActivityId} :Notfication Sent {message.id} {message.to}.");

        }
    }
}

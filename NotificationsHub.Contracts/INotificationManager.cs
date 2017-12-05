using CommunicationsHub.Common;
using NotificationsHub.Models;
using System.Threading.Tasks;

namespace NotificationManager.Contracts
{
    public interface INotificationManager
    {
        Task<string> NotifyAsync(Message message);
        Task<string> NotifyAsync(Message message, string ActivityId);
        Task<string> RegisterApplicationChannels(string appId, NotificationType[] notificationTypes);
    }
}

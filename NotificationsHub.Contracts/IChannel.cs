
namespace NotificationsHub.Contracts
{
    
    using NotificationsHub.Models;
    using System.Threading.Tasks;

    public interface IChannel
    {
        Task Send(Message message, string ActityId);
    }
}

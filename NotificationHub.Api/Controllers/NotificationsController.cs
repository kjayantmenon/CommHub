using NotificationManager;
using NotificationManager.Contracts;
using NotificationsHub.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace NotificationHub.Api.Controllers
{
    public class NotificationsController : ApiController
    {
        INotificationManager _notificationManager= null;
        public NotificationsController(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }
        [HttpPost]
        [Route("api/notifications/notify")]
        public async Task<IHttpActionResult> Notify(Message message)
        {
            //TODO: Move this Constructor injection
            INotificationManager notificationManager = new NotificationManager.NotificationManager();
            await _notificationManager.Notify(message);
            return Ok("Message sent");
        }
    }
}

using CommunicationsHub.Common;
using NotificationManager;
using NotificationManager.Contracts;
using NotificationsHub.Models;
using Serilog;
using System.Threading.Tasks;
using System.Web.Http;

namespace NotificationHub.Api.Controllers
{
    public class NotificationsController : ApiController
    {
        INotificationManager _notificationManager= null;
        ILogger _logger = null;
        public NotificationsController(INotificationManager notificationManager, ILogger logger )
        {
            _notificationManager = notificationManager;
            _logger = logger;
        }
        [HttpPost]
        [Route("api/notifications/notify")]
        public async Task<IHttpActionResult> Notify(Message message)
        {
            _logger.Information("Notify invoked!");
            //INotificationManager notificationManager = new NotificationManager.NotificationManager();
            await _notificationManager.NotifyAsync(message);
            _logger.Information("Notify complete!");
            return Ok("Message sent");
        }

        [HttpPost]
        [Route("api/notifications/register/{appId}")]
        public async Task<IHttpActionResult> registerApplication([FromUri]string appId, NotificationType[] notificationTypes )
        {
            _logger.Information("Registering a new Application");
            await _notificationManager.RegisterApplicationChannels(appId, notificationTypes);
            _logger.Information("Successfully registered the application");
            return Ok("Successfully registered the application");
        }
    }
}

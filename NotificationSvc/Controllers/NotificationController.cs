
namespace NotificationSvc.Controllers
{

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using NotificationManager;
    using NotificationManager.Contracts;
    using NotificationManager.Models;

    [Produces("application/json")]
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
        
        [HttpPost]
        public async Task<IActionResult> Notify(Message message)
        {
            //TODO: Move this Constructor injection
            INotificationManager notificationManager = new NotificationManager();
            notificationManager.Notify(message);
            return Ok("Message sent");
        }
    }
}
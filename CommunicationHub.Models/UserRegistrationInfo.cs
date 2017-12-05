using CommunicationsHub.Common;
using System.Collections.Generic;

namespace CommunicationHub.Models
{
    public class UserRegistrationInfo
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string AppId { get; set; }

        public List<NotificationType> NotificationType { get; set; }
    }
}

using CommunicationHub.Common;
using NotificationsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationHub.Models
{
    public class AppRegistrationInfo
    {
        public string Id { get; set; }
        
        public string AppId { get; set; }

        public List<ChannelInfo> Channels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationHub.Common
{
    public class ChannelInfo
    {
        public string Id { get; set; }
        public Priority Priority { get; set; }
        public ChannelDetails ChannelDetails { get; set; }
        
    }
}

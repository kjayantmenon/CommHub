namespace CommunicationHub.Common
{
    
    using Newtonsoft.Json.Linq;

    public class ChannelDetails
    {
        public string Name { get; set; }
        //Json string - dynamic information that can be system specific
        public JObject Metadata { get; set; }
        public string Url { get; set; }
    }
}
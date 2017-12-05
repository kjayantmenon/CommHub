using System;
using System.Collections.Generic;

namespace NotificationsHub.Models
{
    public class Message
    {

        public Person sender{ get; set; }
        public List<Person> to{ get; set; } 
        public string header { get; set; }

        private MessageBody _data = null;
        public MessageBody data {
            get {return _data; }
            set {_data=value; }
        }
        public int id { get; set; }
        
        
    }

    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class MessageBody
    {
        public string bodyText { get; set; }
    }
}

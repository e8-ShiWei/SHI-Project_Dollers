using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dollers.model
{
    public class Message
    {
        public bool is_message { set; get; }
        public string user_name { set; get; }
        public string user_profile { set; get; }
        public string content { set; get; }
        public string create_time { set; get; }
        public Message(bool is_message, string content, User u)
        {
            this.is_message = is_message;
            this.content = content;
            this.create_time = DateTime.Now.ToString();
            if (is_message)
            {
                user_name = u.name;
                user_profile = u.profile;
            }
            else
            {
                this.content = "—— " + u.name + " " + content;
            }
        }
    }
}
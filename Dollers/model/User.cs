using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dollers.model
{
    public class User
    {
        public int ID { set; get; }
        public string name { set; get; }
        public string profile { set; get; }
        public int? room_ID { set; get; }
        public string create_time { set; get; }
        public User(int ID, string name)
        {
            this.name = name;
            this.profile = getProfileUrl();
            this.room_ID = null;
            this.create_time = DateTime.Now.ToString();
        }
        private string getProfileUrl()
        {
            Random r = new Random();
            return "images/" + r.Next(10) + ".jpg";
        }
    }
}
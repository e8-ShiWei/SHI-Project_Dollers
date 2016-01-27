using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dollers.model
{
    public class Room
    {
        public int ID { set; get; }
        public string name { set; get; }
        public string create_time { set; get; }
        public bool has_pwd { set; get; }
        public string question { set; get; }
        public string pwd { set; get; }
        public int max_count { set; get; }
        public int count { set; get; }
        public List<Message> message_list { set; get; }
        public List<User> user_list { set; get; }
        public Room(int ID, string name, int max_count)
        {
            init(ID, name, max_count);
        }
        public Room(int ID, string name, string question, string pwd, int max_count)
        {
            this.has_pwd = true;
            this.question = question;
            this.pwd = pwd;
            init(ID, name, max_count);
        }
        private void init(int ID, string name, int max_count)
        {
            this.ID = ID;
            this.name = name;
            this.max_count = max_count;
            this.count = 0;
            this.message_list = new List<Message>();
        }
        public void addNewMessage(Message m)
        {
            message_list.Add(m);
        }
        public bool loginRoom(string pwd)
        {
            if (pwd.Equals(this.pwd)) return true;
            else return false;
        }
    }
}
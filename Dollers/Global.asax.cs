using Dollers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Dollers
{
    public class Global : System.Web.HttpApplication
    {
        User u;
        Room r;
        MainController mainController;
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["MainController"] = new MainController();
            Application["count"] = 0;
            Application["room_list"] = new List<string>();
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["count"] = (int)Application["count"] - 1;
            Application.UnLock();
            if (Session["user"] != null)
            {
                u = Session["user"] as Dollers.model.User;
                if (Application[u.room_ID.ToString()] != null)
                {
                    Application.Lock();
                    r = Application[u.room_ID.ToString()] as Dollers.model.Room;
                    r.addNewMessage(new Dollers.model.Message(false, "断开连接", u));
                    r.count--;
                    if (r.count <= 0)
                    {
                        List<string> list = Application["room_list"] as List<string>;
                        list.Remove(r.name);
                        Application["room_list"] = list;
                        Application[u.room_ID.ToString()] = null;
                        Application[u.room_ID.ToString() + "_flag"] = null;
                    }
                    else
                    {
                        Application[u.room_ID.ToString()] = r;
                        Application[u.room_ID.ToString() + "_flag"] = DateTime.Now;
                    }
                    Application.UnLock();
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
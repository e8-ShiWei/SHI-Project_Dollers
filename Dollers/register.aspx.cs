using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dollers
{
    public partial class register : System.Web.UI.Page
    {
        Dollers.model.User u;
        Dollers.model.Room r;
        List<string> room_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                u = Session["user"] as Dollers.model.User;
                if (!u.room_name.Equals(""))
                    Response.Redirect("room.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            string roomName = Server.HtmlEncode(room_name.Value);
            int maxCount = int.Parse(max_count.Value);
            if (!roomName.Equals("") && room_name.Value.Length < 10)
            {
                r = new model.Room(roomName, "", maxCount);
                room_list = Application["room_list"] as List<string>;
                Application.Lock();
                room_list.Add(r.name);
                Application["room_list"] = room_list;
                Application[r.name] = r;
                Application[r.name + "_flag"] = DateTime.Now;
                Application.UnLock();
                Response.Redirect("room.aspx?room=" + HttpUtility.UrlEncode(r.name));
            }
        }
    }
}
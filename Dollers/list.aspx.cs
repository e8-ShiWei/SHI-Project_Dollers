using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dollers
{
    public partial class list : System.Web.UI.Page
    {
        Dollers.model.User u;
        Dollers.model.Room r;
        List<string> room_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                u = Session["user"] as Dollers.model.User;
                if (!u.room_ID.Equals(""))
                    Response.Redirect("room.aspx");
                room_list = Application["room_list"] as List<string>;
                room_Repeater.DataSource = room_list;
                room_Repeater.DataBind();
                username.Text = u.name;
                profile.ImageUrl = u.profile;
                count.Text = Application["count"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void exitBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        public string getCountAndMaxCount(string roomName)
        {
            string str = "";
            r = Application[roomName] as Dollers.model.Room;
            str = r.count + "&nbsp;/&nbsp;" + r.max_count;
            return str;
        }

        public bool roomIsFull(string roomName)
        {
            r = Application[roomName] as Dollers.model.Room;
            if (r.max_count == r.count)
                return true;
            else
                return false;
        }
    }
}
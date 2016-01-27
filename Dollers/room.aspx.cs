using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dollers
{
    public partial class room : System.Web.UI.Page
    {
        Dollers.model.User u;
        Dollers.model.Room r;
        List<Dollers.model.Message> message_list;
        DateTime now, flash_flag, last_message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                last_message = DateTime.Now;
                u = Session["user"] as Dollers.model.User;
                name.Text = u.name;
                if (u.room_name == "" && Request.QueryString["room"] != null && !Request.QueryString["room"].Equals(""))
                {
                    u.room_name = Request.QueryString["room"];
                    Session["user"] = u;
                    Application.Lock();
                    r = Application[u.room_name] as Dollers.model.Room;
                    if (r.count >= r.max_count)
                    {
                        Response.Redirect("list.aspx");
                    }
                    r.addNewMessage(new Dollers.model.Message(false, "进入房间", u));
                    r.count++;
                    last_message = DateTime.Now;
                    Application[u.room_name] = r;
                    Application.UnLock();
                }
                if (Application[u.room_name] == null)
                    Response.Redirect("list.aspx");
                Application.Lock();
                Application[u.room_name + "_flag"] = DateTime.Now;
                Application.UnLock();
                messagesDand();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            now = DateTime.Now;
        }

        private void messagesDand()
        {
            r = Application[u.room_name] as Dollers.model.Room;
            var query = from items in r.message_list orderby items.create_time descending select items;
            message_list = new List<model.Message>();
            foreach (Dollers.model.Message m in query)
            {
                message_list.Add(m);
            }
            message_Repeater.DataSource = message_list;
            message_Repeater.DataBind();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            string content = message_text.Text;
            if (!content.Equals("") && content.Length <= 240)
            {
                Application.Lock();
                r = Application[u.room_name] as Dollers.model.Room;
                r.addNewMessage(new Dollers.model.Message(true, Server.HtmlEncode(content), u));
                Application[u.room_name] = r;
                Application.UnLock();
                message_text.Text = "";
                Application.Lock();
                Application[u.room_name + "_flag"] = DateTime.Now;
                Application.UnLock();
                last_message = DateTime.Now;
            }
            messagesDand();
        }

        protected void signout_btn_Click(object sender, EventArgs e)
        {
            if (Application[u.room_name] != null && !u.room_name.Equals(""))
            {
                Application.Lock();
                r = Application[u.room_name] as Dollers.model.Room;
                r.addNewMessage(new Dollers.model.Message(false, "退出房间", u));
                last_message = DateTime.Now;
                r.count--;
                if (r.count <= 0)
                {
                    List<string> list = Application["room_list"] as List<string>;
                    list.Remove(r.name);
                    Application["room_list"] = list;
                    Application[u.room_name] = null;
                    Application[u.room_name + "_flag"] = null;
                }
                else
                {
                    Application[u.room_name] = r;
                    Application[u.room_name + "_flag"] = DateTime.Now;
                }
                Application.UnLock();
            }
            u.room_name = "";
            Session["User"] = u;
            Response.Redirect("list.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Application[u.room_name + "_flag"] != null)
                flash_flag = (DateTime)Application[u.room_name + "_flag"];
            if (DateTime.Compare(flash_flag, now) >= 0)
            {
                messagesDand();
                UpdatePanel1.Update();
            }
            if (DateDiff(now, last_message) >= 30)
            {

            }
            now = DateTime.Now;
        }
        //计算时间的差值
        public double DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return ts.TotalMinutes;
            #region note
            //C#中使用TimeSpan计算两个时间的差值
            //可以反加两个日期之间任何一个时间单位。
            //TimeSpan ts = Date1 - Date2;
            //double dDays = ts.TotalDays;//带小数的天数，比如1天12小时结果就是1.5 
            //int nDays = ts.Days;//整数天数，1天12小时或者1天20小时结果都是1  
            #endregion
        }
    }
}

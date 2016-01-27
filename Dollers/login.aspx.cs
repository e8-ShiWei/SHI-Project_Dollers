using Dollers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dollers
{
    public partial class login : System.Web.UI.Page
    {
        MainController mainController;
        protected void Page_Load(object sender, EventArgs e)
        {
            mainController = Application["MainController"] as MainController;
            if (Session["user"] != null)
            {
                Response.Redirect("list.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (!name.Text.Equals("") && name.Text.Length < 10)
            {
                Session["user"] = mainController.createUser(Server.HtmlEncode(name.Text));
                Application.Lock();
                Application["count"] = (int)Application["count"] + 1;
                Application["MainController"] = mainController;
                Application.UnLock();
                Response.Redirect("list.aspx");
            }
        }
    }
}
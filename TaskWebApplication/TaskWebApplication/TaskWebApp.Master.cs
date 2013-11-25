using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskWebApplication.Domain;

namespace TaskWebApplication
{
    public partial class TaskAppMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] != null)
            {
                login.Attributes["data-current-user"] = ((MembershipUser)Session["currentUser"]).UserName;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (System.Web.Security.Membership.ValidateUser(username.Text, password.Text))
            {
                Session["currentUser"] = System.Web.Security.Membership.GetUser(username.Text);
                login.Attributes["data-current-user"] = ((MembershipUser)Session["currentUser"]).UserName;
            }
            else
            {
                login.Attributes["data-current-user"] = "";
            }
            ScriptManager.RegisterStartupScript(
                     this,
                     typeof(MasterPage),
                     "display",
                     "loginUser()",
                     true);


        }
    }
}
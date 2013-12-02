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

        /// <summary>
        /// This method handles the click for the login form.
        /// </summary>
        /// <param name="sender">the sending object</param>
        /// <param name="e">event arguments</param>
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

        /// <summary>
        /// This method handles the click for the registration form.
        /// </summary>
        /// <param name="sender">the sending object</param>
        /// <param name="e">event arguments</param>
        protected void Register_Click(object sender, EventArgs e)
        {
            String username = registerUser.Text;
            String email = registerEmail.Text;
            String password = registerPassword.Text;
            String confirmedPassword = confirmPassword.Text;
            if (password == confirmedPassword)
            {
                try
                {
                    MembershipUser user = System.Web.Security.Membership.CreateUser(username, password, email);
                    if (user != null)
                    {
                        Session["currentUser"] = System.Web.Security.Membership.GetUser(user.UserName);
                        login.Attributes["data-current-user"] = ((MembershipUser)Session["currentUser"]).UserName;
                    }
                    else
                    {
                        login.Attributes["data-current-user"] = "";
                    }
                }
                catch (Exception ex)
                {
                    login.Attributes["data-current-user"] = "";
                    Console.WriteLine(ex);
                }
            }
            else
            {
                login.Attributes["data-current-user"] = "";
            }

            ScriptManager.RegisterStartupScript(
                    this,
                    typeof(MasterPage),
                    "display",
                    "registerUser()",
                    true);


        }
    }
}
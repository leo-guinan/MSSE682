using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskApp.Business;

namespace TaskWebApplication
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddTask_Click(object sender, EventArgs e)
        {           
            TaskManager.addTask(name.Text, notes.Text, description.Text, DateTime.Now, DateTime.Parse(dueDate.Text), int.Parse(priority.Text), int.Parse(time.Text), type.Text);
            Response.Redirect("ListAllTasks.aspx");
        }
    }
}
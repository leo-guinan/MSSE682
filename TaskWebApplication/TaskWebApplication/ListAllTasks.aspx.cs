using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskApp.Business;
using TaskWebApplication.Domain;

namespace TaskWebApplication
{
    public partial class ListAllTasks : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Task> allTasks = TaskManager.getAllTasks();
            listAllTasks.DataSource = allTasks;
            listAllTasks.DataBind();

        }
    }
}
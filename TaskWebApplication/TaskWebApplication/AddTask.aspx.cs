﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskWebApplication
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddTask_Click(object sender, EventArgs e)
        {
            submit.Text = "Clicked!";
            Response.Redirect("ListAllTasks.aspx");
        }
    }
}
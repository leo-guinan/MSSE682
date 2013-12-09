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

           


        }

        protected void Page_Init(object sender, EventArgs e)
        {

            List<Task> allTasks = TaskManager.getAllTasks();
            listAllTasks.DataSource = allTasks;
            listAllTasks.DataBind();

            foreach (WebControl c in FindRecursive(Page, c => (c is WebControl) &&
                                   ((WebControl)c).CssClass == "EDIT"))
            {
                Button button = (Button)c;
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.EventName = "Click";
                trigger.ControlID = button.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);
               
            }
            foreach (WebControl c in FindRecursive(Page, c => (c is WebControl) &&
                                   ((WebControl)c).CssClass == "DELETE"))
            {
                Button button = (Button)c;
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.EventName = "Click";
                trigger.ControlID = button.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);

            }

        }



        protected void EditClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            String id = clicked.Attributes["data-id"];
            foreach (WebControl c in FindRecursive(Page, c => (c is WebControl) &&
                           ((WebControl)c).CssClass == id))
            {
                c.Enabled = true;

            }
            clicked.Enabled = false;
            UpdatePanel1.Update();

        }

        protected void EditSubmitClick(object sender, EventArgs e)
        {
            String name = "", description = "", notes = "", estimateType = "";
            int priority = -1, estimateTime = -1;
            DateTime dueDate = DateTime.Now, dateCreated = DateTime.Now;

            TextBox changed = (TextBox)sender;
            String id = changed.CssClass;
            foreach (WebControl c in FindRecursive(Page, c => (c is WebControl) &&
                           ((WebControl)c).CssClass == id))
            {
                TextBox textBox = (TextBox)c;
                switch (c.Attributes["data-field"])
                {
                    case "name":
                        
                        name = textBox.Text;
                        break;
                    case "description":
                        description = textBox.Text;
                        break;
                    case "notes":
                        notes = textBox.Text;
                        break;
                    case "priority":
                        priority = int.Parse(textBox.Text);
                        break;
                    case "dueDate":
                        dueDate = DateTime.Parse(textBox.Text);
                        break;
                    case "dateCreated":
                        dateCreated = DateTime.Parse(textBox.Text);
                        break;
                    case "estimateType":
                        estimateType = textBox.Text;
                        break;
                    case "estimateTime":
                        estimateTime = int.Parse(textBox.Text);
                        break;
                    default:
                        break;
                }
            }
            TaskManager.modifyTask(name, notes, description, dateCreated, dueDate, priority, estimateTime, estimateType, int.Parse(id));
            Response.Redirect(Request.RawUrl);

        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int id = int.Parse(clicked.Attributes["data-id"]);
            TaskManager.DeleteTask(id);
            Response.Redirect(Request.RawUrl);

        }

        // utility method to recursively find controls matching a predicate
        IEnumerable<Control> FindRecursive(Control c, Func<Control, bool> predicate)
        {
            if (predicate(c))
                yield return c;

            foreach (var child in c.Controls)
            {
                if (predicate(c))
                    yield return c;
            }

            foreach (var child in c.Controls)
                foreach (var match in FindRecursive((Control)child, predicate))
                    yield return match;
        }

    }
}
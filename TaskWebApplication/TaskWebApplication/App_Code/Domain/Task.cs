using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Domain
{
    public partial class Task
    {
        public Task()
        {
        }

        public int id { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
        public System.DateTime dateCreated { get; set; }
        public System.DateTime dueDate { get; set; }
        public Estimate estimate { get; set; }
        public bool validateTask()
        {
            return this.name != null;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to ThreeDPoint return false:
            Task task = obj as Task;
            if ((object)task == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.id == task.id
                && this.description.Equals(task.description)
                && this.notes.Equals(task.notes)
                && this.name.Equals(task.name)
                && this.priority == task.priority
                && this.dueDate.Equals(task.dueDate)
                && this.dateCreated.Equals(task.dateCreated)
                && this.estimate.Equals(task.estimate);
        }



        public override int GetHashCode()
        {
            return this.id ^
                this.description.GetHashCode() ^
                this.notes.GetHashCode() ^
                this.name.GetHashCode() ^
                this.priority ^
                this.dueDate.GetHashCode() ^
                this.dateCreated.GetHashCode() ^
                this.estimate.GetHashCode();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Domain
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

        public bool validateTask()
        {
            return this.name != null;
        }

    }
}
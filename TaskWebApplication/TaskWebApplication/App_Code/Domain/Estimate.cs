using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Domain
{
    public partial class Estimate
    {
        public int id { get; set; }
        public int time { get; set; }
        public string type { get; set; }
        public int taskId { get; set; }
    

        public bool validateEstimate()
        {
            return this.type != null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Domain
{
    public partial class Estimate
    {
        public int time { get; set; }
        public string type { get; set; }
    
        public bool validateEstimate()
        {
            return this.type != null;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to ThreeDPoint return false:
            Estimate p = obj as Estimate;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.time == p.time && this.type.Equals(p.type);
        }

     
        public override int GetHashCode()
        {
            return this.time.GetHashCode() ^ this.type.GetHashCode();
        }
    }
}
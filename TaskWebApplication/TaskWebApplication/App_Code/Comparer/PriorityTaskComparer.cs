using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApplication.Domain;

namespace TaskApp.Comparer
{
    public class PriorityTaskComparer : IComparer<Task>
    {
        int IComparer<Task>.Compare(Task x, Task y)
        {
            if (x.priority > y.priority)
            {
                return 1;

            }
            if (x.priority < y.priority)
            {
                return -1;

            }
            return 0;
        }

    }
}
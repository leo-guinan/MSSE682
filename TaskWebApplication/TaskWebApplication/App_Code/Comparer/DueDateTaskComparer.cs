using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.Comparer
{
    public class DueDateTaskComparer : IComparer<Task>
    {
        int IComparer<Task>.Compare(Task x, Task y)
        {
            if (x.dueDate > y.dueDate)
            {
                return 1;

            }
            if (x.dueDate < y.dueDate)
            {
                return -1;

            }
            return 0;
        }

    }
}
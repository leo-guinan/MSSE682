using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.Comparer
{
    public class DateCreatedTaskComparer : IComparer<Task>
    {
        int IComparer<Task>.Compare(Task x, Task y)
        {
            if (x.dateCreated > y.dateCreated)
            {
                return 1;

            }
            if (x.dateCreated < y.dateCreated)
            {
                return -1;

            }
            return 0;
        }

    }
}
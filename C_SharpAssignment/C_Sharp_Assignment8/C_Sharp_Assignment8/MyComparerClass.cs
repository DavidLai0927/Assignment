using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment8
{
    public class MyComparerClass : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    Student a = x; Student b = y;
                    return ((new CaseInsensitiveComparer()).Compare(a.firstName, b.firstName));
                }
            }


        }
    }
}

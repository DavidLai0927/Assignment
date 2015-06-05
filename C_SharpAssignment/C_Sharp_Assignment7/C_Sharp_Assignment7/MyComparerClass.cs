using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment7
{
    public class MyComparerClass : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Student a = (Student)x; Student b = (Student)y;
            return ((new CaseInsensitiveComparer()).Compare(a.firstName, b.firstName));
        }
    }
}

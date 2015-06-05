using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment6
{
    public class Student : Person
    {
        public void TakeTest()
        {
            Console.WriteLine("Student {0} takes test.", name);
        }
    }
}

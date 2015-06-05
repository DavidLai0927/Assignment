using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment8
{
    public class Course
    {
        public string name { get; set; }
        //public string teacher { get; set; }
        public string time { get; set; }
        //public ArrayList students = new ArrayList();
        public List<Student> students = new List<Student>();
        public Teacher[] teachers = new Teacher[3];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment5
{

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Amy", "AAA");
            Student student2 = new Student("Bob", "BBB");
            Student student3 = new Student("Cindy", "CCC");
            Course course = new Course();
            course.name = "Programming with C#";
            course.students[0] = student1;
            course.students[1] = student2;
            course.students[2] = student3;
            Teacher teacher1 = new Teacher("David", "DDD");
            course.teachers[0] = teacher1;
            Degree degree = new Degree("Bachelor");
            UProgram uprogram = new UProgram("Information Technology");

            Console.WriteLine("The {0} programs contains the {1} degree", uprogram.name, degree.deg);
            Console.WriteLine("The {0} degree contains the course {1}", degree.deg, course.name);
            Console.WriteLine("The {0} course contains {1} student(s)", course.name, course.students.Length);
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadLine();
        }
    }
}

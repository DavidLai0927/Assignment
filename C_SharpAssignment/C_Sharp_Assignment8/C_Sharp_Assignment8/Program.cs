using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *這是C# Module 8 Challenge 
 * base on Module 8 
 * 修改 Student Grade Type
*/

namespace C_Sharp_Assignment8
{
 
    class Program
    {
        static void ListStudents(Course cource)
        {
            foreach (Student sd in cource.students)
            {
                Console.WriteLine("First Name: {0} , Last Name: {1}", sd.firstName, sd.lastName);
            }

        }

        static void Main(string[] args)
        {
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            student1.lastName = "John"; student1.firstName = "Lee";
            student2.lastName = "David"; student2.firstName = "Wang";
            student3.lastName = "Rebecca"; student3.firstName = "Lai";
            student1.Grades.Add(60); student1.Grades.Add(70); student1.Grades.Add(80); student1.Grades.Add(90); student1.Grades.Add(100);
            student2.Grades.Add(100); student2.Grades.Add(10); student2.Grades.Add(10); student2.Grades.Add(100); student2.Grades.Add(100);
            student3.Grades.Add(60); student3.Grades.Add(50); student3.Grades.Add(40); student3.Grades.Add(30); student3.Grades.Add(20);
            Course cource = new Course();
            cource.name = "Programming with C#";
            cource.students.Add(student1);
            cource.students.Add(student2);
            cource.students.Add(student3);
            ListStudents(cource);
            Console.WriteLine();
            MyComparerClass myComparer = new MyComparerClass();
            cource.students.Sort(myComparer);
            ListStudents(cource);
            Console.WriteLine();
           
            foreach (Student sd in cource.students)
            {
                sd.Grades.Sort();
                Console.WriteLine("First Name: {0} , Last Name: {1}", sd.firstName, sd.lastName);
                Console.WriteLine("Sorted Grade below");
                foreach(int i in sd.Grades) {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }
    }


}

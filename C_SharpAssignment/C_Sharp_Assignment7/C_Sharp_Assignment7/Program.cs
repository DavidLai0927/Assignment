using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Sharp_Assignment7
{

    class Program
    {
        static void ListStudents(Course cource)
        {
            foreach (Student sd in cource.students)
            {
                Console.WriteLine("First Name: {0} , Last Name: {1}" , sd.firstName, sd.lastName);
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
            student1.score.Push(60); student1.score.Push(70); student1.score.Push(80); student1.score.Push(90); student1.score.Push(100);
            student2.score.Push(100); student2.score.Push(10); student2.score.Push(10); student2.score.Push(100); student2.score.Push(100);
            student3.score.Push(60); student3.score.Push(50); student3.score.Push(40); student3.score.Push(30); student3.score.Push(20);
            Course course = new Course();
            course.name = "Programming with C#";
            course.students.Add(student1);
            course.students.Add(student2);
            course.students.Add(student3);
            ListStudents(course);
            Console.WriteLine();
            //challenge below
            IComparer myComparer = new MyComparerClass();
            course.students.Sort(myComparer);
            ListStudents(course);
            Console.WriteLine();
            //bonus challenfe below
            Stack<int> tmp = new Stack<int>();
            tmp.Push(student1.score.Pop());
            tmp.Push(student1.score.Pop());
            student1.score.Peek();
            student1.score.Push(tmp.Pop());
            student1.score.Push(tmp.Pop());
            foreach (Student sd in course.students)
            {
                Console.Write("First Name: {0} , Last Name: {1} Grade : ", sd.firstName, sd.lastName);
                while (sd.score.Count != 0)
                {
                    Console.Write("{0} ", sd.score.Peek()); 
                    tmp.Push(sd.score.Pop());
                }
                while (tmp.Count != 0)
                {
                    sd.score.Push(tmp.Pop());
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    
}

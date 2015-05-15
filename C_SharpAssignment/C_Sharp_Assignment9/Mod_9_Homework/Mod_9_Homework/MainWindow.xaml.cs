using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Student> studentList = new List<Student>();
        int indexOfList = 0;
        private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.firstName = txtFirstName.Text;
            student.lastName = txtLastName.Text;
            student.city = txtCity.Text;
            studentList.Add(student);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (indexOfList >= 0)
            {
                txtFirstName.Text = studentList[indexOfList].firstName;
                txtLastName.Text = studentList[indexOfList].lastName;
                txtCity.Text = studentList[indexOfList].city;
                indexOfList--;
            }
            else if (indexOfList == -1)
            {
                indexOfList = studentList.Count - 1;
                txtFirstName.Text = studentList[indexOfList].firstName;
                txtLastName.Text = studentList[indexOfList].lastName;
                txtCity.Text = studentList[indexOfList].city;
                indexOfList--;
            }
                
            
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (indexOfList <= studentList.Count-1)
            {         
                txtFirstName.Text = studentList[indexOfList].firstName;
                txtLastName.Text = studentList[indexOfList].lastName;
                txtCity.Text = studentList[indexOfList].city;
                indexOfList++;
            }
            else if (indexOfList == studentList.Count)
            {
                indexOfList = 0;
                txtFirstName.Text = studentList[indexOfList].firstName;
                txtLastName.Text = studentList[indexOfList].lastName;
                txtCity.Text = studentList[indexOfList].city;
                indexOfList++;
            }
                
            
        }
    }

    public class Student {
        public string firstName,lastName,city;
        public Student()
        {
        }
        public Student(string firstName,string lastName,string city) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
        }
    }
}

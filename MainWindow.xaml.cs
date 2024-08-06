using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalVasuTevar
{
    
    public partial class MainWindow : Window
    {
        //definition of context class
        StudentContext db = new StudentContext();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoadStudentGrd()
        {
            //loading data seed into datagrid
            StudentsGrd.ItemsSource = db.Students.ToList();
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadStudentGrd();
        }

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            // clear all fields and data
            txtName.Clear();
            txtAge.Clear();
            txtGPA.Clear();
            StudentsGrd.ItemsSource = null;
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {

            //checking that gpa should be in range of 0.0 to 4.0
            if (double.TryParse(txtGPA.Text, out double gpa) && gpa >= 0.0 && gpa <= 4.0)
            {
                var student = new Student
                {
                    Name = txtName.Text,
                    Age = int.Parse(txtAge.Text),
                    GPA = gpa,
                    IsHonors = gpa >= 3.5
                };

                db.Students.Add(student);
                db.SaveChanges();

                MessageBox.Show("Student added successfully!");
                LoadStudentGrd(); // Refresh the data grid
            }
            else
            {
                MessageBox.Show("GPA must be in the range of 0.0 to 4.0.");
            }
        }
    }
}
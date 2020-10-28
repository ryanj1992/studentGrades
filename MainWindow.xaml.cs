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
using System.Data.Entity;

namespace Johnson_Ryan_1310903
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Entities context;
        private List<Student> students;
        private System.Windows.Data.CollectionViewSource studentViewSource;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Show message box confirming if the user wants to exit the application
        private void Exit_Window(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new Entities();
            studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            OnRefresh(sender, e);
            // Load data by setting the CollectionViewSource.Source property:
            // studentViewSource.Source = [generic data source]
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            var query = from student in context.Students
                        select student;
            // convert set of Students objects to list of Student objects
            students = query.ToList();
            studentViewSource.Source = students;
        }

        public void AnalysisTable(object sender, RoutedEventArgs e)
        {
            AnalysisTable analysis = new AnalysisTable(); // Create window object.
            Nullable<bool> result = analysis.ShowDialog(); // Make window modal and collect result.
            string interaction = string.Empty;
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            // find which button triggered the event
            Button button = sender as Button;
            // use the button's DataContext property to find the 
            // Student entity associated with the button in the collection view
            Student student = (Student)button.DataContext;
            // now prepare a dialog
            // passing the Student entities current values of
            // properties First name, last name, matric no, comp a, comp b and comp c as default user choices
            EditDialog dialog = new EditDialog(student.FirstName, student.LastName,
                student.MatricNo, student.CompA, student.CompB, student.CompC, student.FinalGrade);
            // Show the dialog
            Nullable<bool> result = dialog.ShowDialog();
            // property DialogResult will be false if dialog was cancelled
            if (dialog.DialogResult == true)
            {

                string firstName = dialog.txtFirstName.Text;
                string lastName = dialog.txtLastName.Text;
                int matricNo = Convert.ToInt32(dialog.txtMatricNo.Text);
                string compA = dialog.txtCompA.Text;
                string compB = dialog.txtCompB.Text;
                string compC = dialog.txtCompC.Text;
                // only edit new entity if both names, matric no and components are not empty 
                if (firstName != string.Empty
                && lastName != string.Empty && compA != string.Empty && compB != string.Empty && compC != string.Empty)
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.MatricNo = matricNo;
                    student.CompA = compA;
                    student.CompB = compB;
                    student.CompC = compC;


                    // Create new list
                    List<string> grades = new List<string>();

                    // Switch statement that adds the appropriate grades to the list for each component
                    switch (dialog.txtCompA.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    switch (dialog.txtCompB.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    switch (dialog.txtCompC.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    int a = 0;
                    int b = 0;
                    int c = 0;
                    int d = 0;
                    int eLetter = 0;
                    int f = 0;
                    int moreThanB = 0;
                    int moreThanC = 0;
                    int moreThanD = 0;
                    int moreThanE = 0;


                    // Iterates through the list with a foreach loop searching for a specific grade
                    // Increments variable depending what grade has been found
                    foreach (string apple in grades)
                    {
                        if (apple.Equals("A"))
                        {
                            a++;
                            moreThanB++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("B"))
                        {
                            b++;
                            moreThanB++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("C"))
                        {
                            c++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("D"))
                        {
                            d++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("E"))
                        {
                            eLetter++;
                            moreThanE++;
                        }
                        else if (apple.Equals("F"))
                        {
                            f++;
                        }
                    }

                    // If statement working out the final grade

                    if (a >= 5 && moreThanB >= 7 && moreThanC >= 10)
                    {
                        student.FinalGrade = "A";
                    }
                    else if (moreThanB >= 5 && moreThanC >= 7 && moreThanD >= 10)
                    {
                        student.FinalGrade = "B";
                    }
                    else if (moreThanC >= 5 && moreThanD >= 7)
                    {
                        student.FinalGrade = "C";
                    }
                    else if (moreThanD >= 5 && moreThanE >= 7)
                    {
                        student.FinalGrade = "D";
                    }
                    else if (moreThanE >= 7)
                    {
                        student.FinalGrade = "E";
                    }
                    else
                    {
                        student.FinalGrade = "F";
                    }

                    context.SaveChanges();
                    OnRefresh(sender, e);
                }
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            // find which button triggered the event
            Button button = sender as Button;
            // use the button's DataContext property to find the 
            // Student entity associated with the button in the collection view
            Student student = (Student)button.DataContext;
            // use message box to confirm delete operation
            var result = MessageBox.Show("Delete Student: " + student.LastName + "?",
                "Confirmation",
                MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // remove the student entity from the set of Student 
                // entities mamanged by the database context
                context.Students.Remove(student);
                // now sync with the database i.e.
                // delete row from database Students table 
                context.SaveChanges();
                OnRefresh(sender, e);
            }
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Delete All Students?",
               "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                foreach (var entity in context.Students)
                {
                    context.Students.Remove(entity);
                }

                context.SaveChanges();
                OnRefresh(sender, e);
            }
        }

        // event handler for adding a new student entity
        private void OnAdd(object sender, RoutedEventArgs e)
        {
            // prepare dialog
            AddStudent dialog = new AddStudent();
            // show dialog
            Nullable<bool> result = dialog.ShowDialog();
            // property DialogResult will be false if dialog was cancelled
            if (dialog.DialogResult == true)
            {
                string firstName = dialog.txtFirstName.Text;
                string lastName = dialog.txtLastName.Text;
                int matricNo = Convert.ToInt32(dialog.txtMatricNo.Text);
                string compA = dialog.txtCompA.Text;
                string compB = dialog.txtCompB.Text;
                string compC = dialog.txtCompC.Text;
                // only add new entity if both names, matric no and components are not empty 
                if (firstName != string.Empty
                    && lastName != string.Empty && compA != string.Empty && compB != string.Empty && compC != string.Empty)
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.MatricNo = matricNo;
                    student.CompA = compA;
                    student.CompB = compB;
                    student.CompC = compC;

                    List<string> grades = new List<string>();

                    switch (dialog.txtCompA.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    switch (dialog.txtCompB.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    switch (dialog.txtCompC.SelectedIndex)
                    {
                        case 0:
                            grades.Add("A");
                            grades.Add("A");
                            break;

                        case 1:
                            grades.Add("B");
                            grades.Add("B");
                            break;

                        case 2:
                            grades.Add("C");
                            grades.Add("C");
                            break;

                        case 3:
                            grades.Add("D");
                            grades.Add("D");
                            break;

                        case 4:
                            grades.Add("E");
                            grades.Add("E");
                            break;

                        case 5:
                            grades.Add("F");
                            break;

                        default:
                            grades.Add("F");
                            break;
                    }

                    int a = 0;
                    int b = 0;
                    int c = 0;
                    int d = 0;
                    int eLetter = 0;
                    int f = 0;
                    int moreThanB = 0;
                    int moreThanC = 0;
                    int moreThanD = 0;
                    int moreThanE = 0;

                    foreach (string apple in grades)
                    {
                        if (apple.Equals("A"))
                        {
                            a++;
                            moreThanB++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("B"))
                        {
                            b++;
                            moreThanB++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("C"))
                        {
                            c++;
                            moreThanC++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("D"))
                        {
                            d++;
                            moreThanD++;
                            moreThanE++;
                        }
                        else if (apple.Equals("E"))
                        {
                            eLetter++;
                            moreThanE++;
                        }
                        else if (apple.Equals("F"))
                        {
                            f++;
                        }
                    }

                    if (a >= 5 && moreThanB >= 7 && moreThanC >= 10)
                    {
                        student.FinalGrade = "A";
                    }
                    else if (moreThanB >= 5 && moreThanC >= 7 && moreThanD >= 10)
                    {
                        student.FinalGrade = "B";
                    }
                    else if (moreThanC >= 5 && moreThanD >= 7)
                    {
                        student.FinalGrade = "C";
                    }
                    else if (moreThanD >= 5 && moreThanE >= 7)
                    {
                        student.FinalGrade = "D";
                    }
                    else if (moreThanE >= 7)
                    {
                        student.FinalGrade = "E";
                    }
                    else
                    {
                        student.FinalGrade = "F";
                    }

                    // attach new student entity to the set of
                    // student entities managed by the database context
                    context.Students.Add(student);
                    // now synchronise with the database by
                    // inserting a new row into database Students table
                    context.SaveChanges();
                    OnRefresh(sender, e);
                }
            }
        }
    }
}

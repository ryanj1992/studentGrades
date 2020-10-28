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
using System.Windows.Shapes;


namespace Johnson_Ryan_1310903
{
    /// <summary>
    /// Interaction logic for AnalysisTable.xaml
    /// </summary>
    public partial class AnalysisTable : Window
    {

        private Entities context;
        private List<Student> students;
        private System.Windows.Data.CollectionViewSource studentViewSource;
        public AnalysisTable()
        {
            InitializeComponent();
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

        // adds new Filter Event Handler for students who have passed
        private void StudentPassed(object sender, RoutedEventArgs e)
        {
            studentViewSource.Filter += new FilterEventHandler(PassedFilter);
            OnRefresh(sender, e);
        }

        // adds new Filter Event Handler for students who have failed
        private void StudentFailed(object sender, RoutedEventArgs e)
        {
            studentViewSource.Filter += new FilterEventHandler(FailedFilter);
            OnRefresh(sender, e);
        }

        // Filters out students who have passed
        private void FailedFilter(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Student;
            if (obj != null)
            {
                if (obj.FinalGrade.Equals("E"))
                    e.Accepted = true;
                else if (obj.FinalGrade.Equals("F"))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }

            double percentage = 0;
            double totalCount = students.Count; // counts total students in the collectionViewSource
            double filteredCount = 0;

            // counts total students who have passed/failed depending on which event click is used
            foreach (var item in studentViewSource.View)
            {
                filteredCount++;
            }
            filteredCount = filteredCount - 1;

            percentage = (filteredCount / totalCount) * 100; // calculates percentage of students who have passed/failed
            percentagePassed.Text = percentage.ToString("0") + "% Failed";

            context.SaveChanges();
        }

        // Filters out students who have failed
        private void PassedFilter(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Student;
            if (obj != null)
            {
                if (obj.FinalGrade.Equals("A"))
                    e.Accepted = true;
                else if (obj.FinalGrade.Equals("B"))
                    e.Accepted = true;
                else if (obj.FinalGrade.Equals("C"))
                    e.Accepted = true;
                else if (obj.FinalGrade.Equals("D"))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }

            double percentage = 0;
            double totalCount = students.Count; // counts total students in the collectionViewSource
            double filteredCount = 0;

            // counts total students who have passed/failed depending on which event click is used
            foreach (var item in studentViewSource.View)
            {
                filteredCount++;
            }
            filteredCount = filteredCount - 1;

            percentage = (filteredCount / totalCount) * 100; // calculates percentage of students who have passed/failed
            percentagePassed.Text = percentage.ToString("0") + "% Passed";

            context.SaveChanges();
        }
    }
}

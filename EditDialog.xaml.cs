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
using System.Text.RegularExpressions;

namespace Johnson_Ryan_1310903
{
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {
        public EditDialog(string firstName, string lastName, int matricNo,
            string compA, string compB, string compC, string finalGrade)
        {
            InitializeComponent();

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtMatricNo.Text = matricNo.ToString();
            txtCompA.Text = compA;
            txtCompB.Text = compB;
            txtCompC.Text = compC;

            // Sets matric number text box to take a maximum of 7 numbers
            txtMatricNo.MaxLength = 7;
        }


        // Event handler created to clear all text boxes if button clicked
        public void OnClear(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtMatricNo.Text = String.Empty;
            txtCompA.Text = String.Empty;
            txtCompB.Text = String.Empty;
            txtCompC.Text = String.Empty;
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            // Validations
            // Only accepts letters A-Z and a-z
            Regex r = new Regex("^[a-zA-Z]*$");
            // Only accepts numbers 0-9
            Regex r2 = new Regex("^[0-9]*$");

            if (txtFirstName.Text == string.Empty || !r.IsMatch(txtFirstName.Text))
            {
                if (txtFirstName.Text == string.Empty)
                    MessageBox.Show("Please Enter Your First Name");
                else
                {
                    MessageBox.Show("Please Enter Only Letters");
                }
            }
            // Validation so that text box only accepts letters & checks if its empty
            else if(txtLastName.Text == string.Empty || !r.IsMatch(txtLastName.Text))
            {
                if (txtLastName.Text == string.Empty)
                    MessageBox.Show("Please Enter Your Last Name");
                else
                {
                    MessageBox.Show("Please Enter Only Letters");
                }
            }
            // Validation so that text box only accepts numbers & checks if its empty & makes sure matric no is no less than 7 numbers
            else if (txtMatricNo.Text == string.Empty || !r2.IsMatch(txtMatricNo.Text) || txtMatricNo.Text.Length < 7)
            {
                if (txtMatricNo.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Matriculation Number");
                }
                else if (!r2.IsMatch(txtMatricNo.Text))
                {
                    MessageBox.Show("Please Enter Only Numbers [0-9]");
                }
                else
                {
                    MessageBox.Show("Please Enter a Matriculation Number with 7 numbers");
                }
            }
            else if(txtCompA.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Component A");
            }
            else if(txtCompB.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Component B");
            }
             else if(txtCompC.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Component C");
            }
            else
            {
                // Set DialogResult to true
                // Property DialogResult  is tested by calling code 
                // to determine whether user cancelled dialog
                // or submitted changes
                DialogResult = true;
                // Close the dialog
                Close();
            }
        }
    }
}
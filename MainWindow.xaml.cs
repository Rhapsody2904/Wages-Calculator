/*
 * Milda Willoughby
 * Project 2: Simple wage calculator
 * Use TAB to move between fields; ENTER or Clicking the button will trigger calculation
 */


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
using System.Text.RegularExpressions;

namespace Project3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String first = "";
            String last = "";
            double payRate = 0;
            double hrs = 0;
            Boolean done = false;

            //use regular expression to quickly validate input
            Regex rxName = new Regex("^[A-Za-z ]+$"); //allow to use letters and spaces only
            Regex rxNums = new Regex(@"^[0-9][0-9,\.]+$"); //allow positive numbers only

            if (rxName.IsMatch(fName.Text) && rxName.IsMatch(lName.Text))
            {
                first = fName.Text;
                last = lName.Text;
                done = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Unexpected input. Please use letters only in the name fields.",
                                           "Error!",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Exclamation);
            }

            if (done)//if the names were entered correctly, proceed
            {

                if (rxNums.IsMatch(rate.Text) && rxNums.IsMatch(hours.Text))
                {
                    payRate = double.Parse(rate.Text);
                    hrs = double.Parse(hours.Text);
                    done = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Unexpected input. Please use positive numeric values only in the 'Pay Rate' and 'Hours Worked' fields.",
                                               "Error!",
                                               MessageBoxButton.OK,
                                               MessageBoxImage.Exclamation);
                    done = false;
                    earned.Text = "";
                }
            }

            if (done) //if data validation passed, create object
            {
                Employee emp1 = new Employee(first, last, payRate, hrs);
                earned.Text = (emp1.getEarnings()).ToString(); //get calculation
            }
        }

        //Check if ENTER is pressed while in any of the fields
        private void hours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }

        private void rate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }
        private void fName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }
        private void lName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }
    }
}

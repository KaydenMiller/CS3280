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
using Assignment_5.Extensions;

namespace Assignment_5.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            int age = 0;

            try
            {
                if (!int.TryParse(txtAge.Text, out age)) throw new ArgumentException();

                if (Controllers.UserManager.LoginUser(username, age).Status == Utilities.OperationStatus.Success)
                {
                    Console.WriteLine("The user was logged into the application!");
                    MainMenuWindow mainMenu = new MainMenuWindow();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    // Alert the user that they could not be loged in
                    Console.WriteLine("The user could not be logged into the application!");
                }
            }
            catch (ArgumentException argEx)
            {
                // Tell the user they entered invalid data
                ErrorOutput.Visibility = Visibility.Visible;
                tbkErrorOutput.Text = "ERROR: Invalid user data, please use only numeric values for your age.";
            }
            catch (Exception ex)
            {
                ErrorOutput.Visibility = Visibility.Visible;
                tbkErrorOutput.Text = "ERROR: Unknown System Error. Please see error log.";
                ex.Log();
            }
        }
    }
}

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
    }
}

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

namespace Assignment_1
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

        private void OpenMessageBox1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(tbkMessage1.Text, "Message Box 1", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.OK);

            CheckResult(result);
        }

        private void OpenMessageBox2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(tbkMessage2.Text, "Message Box 1", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.None);

            CheckResult(result);
        }

        private void OpenMessageBox3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(tbkMessage3.Text, "Message Box 1", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);

            CheckResult(result);
        }

        private void CheckResult(MessageBoxResult result)
        {
            switch (result)
            {
                case MessageBoxResult.OK:
                    lblResultOutput.Text = "The message box result was: OK";
                    break;
                case MessageBoxResult.Yes:
                    lblResultOutput.Text = "The message box result was: Yes";
                    break;
                case MessageBoxResult.No:
                    lblResultOutput.Text = "The message box result was: No";
                    break;
                case MessageBoxResult.Cancel:
                    lblResultOutput.Text = "The message box result was: Cancel";
                    break;
                case MessageBoxResult.None:
                    lblResultOutput.Text = "The message box result was: None";
                    break;
                default:
                    lblResultOutput.Text = "This is the default responce, it should not happen.";
                    break;
            }
        }
    }
}

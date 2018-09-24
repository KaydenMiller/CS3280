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

namespace Assignment_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int totalSudents, totalAssignments;
        public string[] studentNames;
        public int[,] studentScores;

        private int studentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

#region UserInputEvents
        /// <summary>
        /// This will grab the counts required for intializing the data from the 
        /// counts section of the UI. It will then init both the studentNames and StudentScores arrays.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitCounts_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtNumStudents.Text, out totalSudents);
            int.TryParse(txtNumAssignments.Text, out totalAssignments);

            studentNames = new string[totalSudents];
            studentScores = new int[totalSudents, totalAssignments];

            for (int i = 0; i < totalSudents; i++)
            {
                studentNames[i] = string.Format("Student #{0}", i + 1);
                for (int j = 0; j < totalAssignments; j++)
                {
                    studentScores[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// This method will take each students scores and reset them to 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < totalSudents; i++)
            { 
                for (int j = 0; j < totalAssignments; j++)
                {
                    studentScores[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// This method will jump to the first student stored in memory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstStudent_Click(object sender, RoutedEventArgs e)
        {
            studentIndex = 0;
            txtStudentName.Text = studentNames[studentIndex];
        }

        private void btnPreviousStudent_Click(object sender, RoutedEventArgs e)
        {
            txtStudentName.Text = studentNames[--studentIndex];
        }

        private void btnNextStudent_Click(object sender, RoutedEventArgs e)
        {
            txtStudentName.Text = studentNames[++studentIndex];
        }

        private void btnLastStudent_Click(object sender, RoutedEventArgs e)
        {
            studentIndex = totalSudents - 1;
            txtStudentName.Text = studentNames[studentIndex];
        }

        private void btnSaveName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtStudentName.Text;
            studentNames[studentIndex] = name;
        }

        private void btnSaveScore_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtAssignmentNumber.Text, out int assignmentNumber);
            int.TryParse(txtAssignmentScore.Text, out int assignmentScore);

            studentScores[studentIndex, assignmentNumber - 1] = assignmentScore;
        }

        private void btnDisplayScores_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("{0,-15}", "STUDENT"));
            for (int index = 0; index < totalAssignments; index++)
            {
                sb.Append(String.Format("{0,-6}", String.Format("#{0}", index + 1)));
            }
            sb.Append(String.Format("{0,-6}{1,-6}\n\n", "AVG", "GRADE"));

            for (int index = 0; index < totalSudents; index++)
            {
                sb.Append(String.Format("{0,-15}", studentNames[index]));
                for (int scoreIndex = 0; scoreIndex < totalAssignments; scoreIndex++)
                {
                    sb.Append(String.Format("{0,-6}", studentScores[index, scoreIndex]));
                }
                sb.Append("\n");
            }

            txtStudentData.Text = sb.ToString();
        }
#endregion
    }
}

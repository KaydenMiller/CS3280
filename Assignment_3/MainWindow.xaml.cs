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
        public int totalStudents, totalAssignments;
        public string[] studentNames;
        public int[,] studentScores;
        public float[] studentAverages;

        private int studentIndex = 0;

        /// <summary>
        /// This is the init function.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            btnFirstStudent.IsEnabled = false;
            btnPreviousStudent.IsEnabled = false;
            btnNextStudent.IsEnabled = false;
            btnLastStudent.IsEnabled = false;
            btnDisplayScores.IsEnabled = false;
            btnSaveName.IsEnabled = false;
            btnSaveScore.IsEnabled = false;
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
            bool isNumericStudentFlag = int.TryParse(txtNumStudents.Text, out totalStudents);
            bool isNumericAssignmentFlag = int.TryParse(txtNumAssignments.Text, out totalAssignments);

            if (!isNumericStudentFlag || !isNumericAssignmentFlag)
            {
                // The values were not numeric
                MessageBox.Show("Please enter only numeric values into Student Counts and Assignment Counts fields.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (totalStudents < 1 || totalStudents > 10)
            {
                MessageBox.Show("Please enter a value between 1 and 10 in the Student Counts text box.", "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (totalAssignments < 1 || totalAssignments > 99)
            {
                MessageBox.Show("Please enter a value between 1 and 99 in the Assignment Counts text box.", "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            studentNames = new string[totalStudents];
            studentScores = new int[totalStudents, totalAssignments];
            studentAverages = new float[totalStudents];

            lblAssignmentNumber.Text = String.Format("Enter Assignment Number (1-{0}):", totalStudents);
                
            // init student scores
            for (int i = 0; i < totalStudents; i++)
            {
                studentNames[i] = string.Format("Student #{0}", i + 1);
                for (int j = 0; j < totalAssignments; j++)
                {
                    studentScores[i, j] = 0;
                }
            }

            // init student averages
            for (int i = 0; i < totalStudents; i++)
            {
                studentAverages[i] = 0;
            }

            // Set the current student equal to the first student
            if (studentNames != null &&
                studentNames[0] != null)
            {
                studentIndex = 0;
                txtStudentName.Text = studentNames[studentIndex];
            }

            // Enable buttons for navigation
            btnFirstStudent.IsEnabled = true;
            btnPreviousStudent.IsEnabled = true;
            btnNextStudent.IsEnabled = true;
            btnLastStudent.IsEnabled = true;
            btnDisplayScores.IsEnabled = true;
            btnSaveName.IsEnabled = true;
            btnSaveScore.IsEnabled = true;
        }

        /// <summary>
        /// This method will take each students scores and reset them to 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            totalStudents = 0;
            totalAssignments = 0;
            studentIndex = 0;

            studentNames = null;
            studentScores = null;

            btnFirstStudent.IsEnabled = false;
            btnPreviousStudent.IsEnabled = false;
            btnNextStudent.IsEnabled = false;
            btnLastStudent.IsEnabled = false;
            btnDisplayScores.IsEnabled = false;
            btnSaveName.IsEnabled = false;
            btnSaveScore.IsEnabled = false;

            lblAssignmentNumber.Text = "Enter Assignment Number (1-X):";
            txtNumStudents.Text = "";
            txtNumAssignments.Text = "";
            txtStudentName.Text = "";
            txtAssignmentNumber.Text = "";
            txtAssignmentScore.Text = "";
            txtStudentData.Text = "";
        }

        /// <summary>
        /// This method will jump to the first student stored in memory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentNames != null && 
                studentNames[0] != null)
            {
                studentIndex = 0;
                txtStudentName.Text = studentNames[studentIndex];
            }
        }
        /// <summary>
        /// This will change the current student Index to the previous student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentNames != null && 
                studentIndex - 1 >= 0)
                txtStudentName.Text = studentNames[--studentIndex];
        }

        /// <summary>
        /// This will change the current student Index to the Next student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentNames != null && 
                studentIndex + 1 <= totalStudents - 1)
                txtStudentName.Text = studentNames[++studentIndex];
        }

        /// <summary>
        /// This will change the current student Index to the last student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentNames != null && 
                studentNames[totalStudents - 1] != null)
            {
                studentIndex = totalStudents - 1;
                txtStudentName.Text = studentNames[studentIndex];
            }
        }

        /// <summary>
        /// This method will save the students name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtStudentName.Text;
            studentNames[studentIndex] = name;
        }

        /// <summary>
        /// This method will update the selected score and save it into the studentScores array.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveScore_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtAssignmentNumber.Text, out int assignmentNumber))
            {
                MessageBox.Show("Please use only numeric values in the Assignment Number field.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(txtAssignmentScore.Text, out int assignmentScore))
            {
                MessageBox.Show("Please use only numeric values in the Assignment Score field.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (assignmentNumber < 1 || assignmentNumber > totalAssignments ||
                assignmentScore < 0 || assignmentScore > 100)
            {
                MessageBox.Show("Please enter a valid assignment number or assignment score.", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            studentScores[studentIndex, assignmentNumber - 1] = assignmentScore;
        }


        /// <summary>
        /// Will display the scores on the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayScores_Click(object sender, RoutedEventArgs e)
        {
            // Calculate Averages once when on display to save resources
            CalculateAverageStudentScores();

            // Display the scores
            var sb = new StringBuilder();
            sb.Append(String.Format("{0,-15}", "STUDENT"));
            for (int index = 0; index < totalAssignments; index++)
            {
                sb.Append(String.Format("{0,-6}", String.Format("#{0}", index + 1)));
            }
            sb.Append(String.Format("{0,-6}{1,-6}\n\n", "AVG", "GRADE"));

            for (int index = 0; index < totalStudents; index++)
            {
                sb.Append(String.Format("{0,-15}", studentNames[index]));
                for (int scoreIndex = 0; scoreIndex < totalAssignments; scoreIndex++)
                {
                    sb.Append(String.Format("{0,-6}", studentScores[index, scoreIndex]));
                }
                sb.Append(String.Format("{0,-6}{1,-6}", studentAverages[index], CalculateGrade(studentAverages[index])));
                sb.Append("\n");
            }

            txtStudentData.Text = sb.ToString();
        }
#endregion
        /// <summary>
        /// This will calculate the average of each students scores
        /// based on all score values. It will then update the scores
        /// array.
        /// </summary>
        private void CalculateAverageStudentScores()
        {
            for (int student = 0; student < totalStudents; student++)
            {
                float[] temp = new float[totalAssignments];

                for (int assignment = 0; assignment < totalAssignments; assignment++)
                {
                    temp[assignment] = studentScores[student, assignment];
                }

                studentAverages[student] = temp.Sum() / (float)totalAssignments;
            }
        }

        /// <summary>
        /// This will determine the grade of the student based on the input score.
        /// </summary>
        /// <param name="score">This should be the average score of the student.</param>
        /// <returns>Grade as string.</returns>
        private string CalculateGrade(float score)
        {
            if (score <= 100 && score >= 93)
                return "A";
            else if (score < 93 && score >= 90)
                return "A-";
            else if (score < 90 && score >= 87)
                return "B+";
            else if (score < 87 && score >= 83)
                return "B";
            else if (score < 83 && score >= 80)
                return "B-";
            else if (score < 80 && score >= 77)
                return "C+";
            else if (score < 77 && score >= 73)
                return "C";
            else if (score < 73 && score >= 70)
                return "C-";
            else if (score < 70 && score >= 67)
                return "D+";
            else if (score < 67 && score >= 63)
                return "D";
            else if (score < 63 && score >= 60)
                return "D-";
            else if (score < 60)
                return "E";
            else
                return "Error!";
        }
    }
}

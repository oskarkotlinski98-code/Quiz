using Labb3_NET22.DataModels;
using Labb3_NET22.Files;
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

namespace Labb3_NET22
{
  
    public partial class CreateQuizWindow : Window
    {
        private readonly List<Question> _Questions = new();
        public CreateQuizWindow()
        {
            InitializeComponent();
        }

        private void AddQuestionClick(object sender, RoutedEventArgs e)
        {
            var addQuestionWindow = new AddQuestionWindow();
            if (addQuestionWindow.ShowDialog() == true || addQuestionWindow.NewQuestion != null)
            {
                _Questions.Add(addQuestionWindow.NewQuestion);
                QuestionList.Items.Add(addQuestionWindow.NewQuestion.Statement);
            }
        }
        private void SaveQuizClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuizTitleBox.Text))
            {
                MessageBox.Show("Please enter a quiz title.");
                return;
            }

            Quiz quiz = new Quiz(QuizTitleBox.Text);
            foreach(Question q in _Questions)
            {
                quiz.AddQuestion(q.Statement, q.CorrectAnswer, q.Answers);
            }

            SaveQuizToFile.SaveQuizJson(quiz);
            MessageBox.Show("Quiz is saved");

        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

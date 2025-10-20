
using System;
using System.Collections.Generic;
using Labb3_NET22.Controls;
using Labb3_NET22.DataModels;
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

namespace Labb3_NET22
{

    public partial class MainWindow : Window
    {
        private QuizSession _session;
        private Question _currentQuestion;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartQuiz(Quiz quiz)
        {
            _session = new QuizSession(quiz);

        }

        private void ShowNextQuestion()
        {
            _currentQuestion = _session.GetNextQuestion();

            if (_currentQuestion == null)
            {
                MessageBox.Show($"You finished the quiz, Score :{_session.GetScorePercent()}%");
                return;
            }


            
            Questionblock.Text = _currentQuestion.Statement;
            AnswerOneButton.Content = _currentQuestion.Answers[0];
            AnswerTwoButton.Content = _currentQuestion.Answers[1];
            AnswerThreeButton.Content = _currentQuestion.Answers[2];
            AnswerFourButton.Content = _currentQuestion.Answers[3];
        }



        private void GuessAnswer(int i)
        {
            bool correct = _session.SubmitAnswer(_currentQuestion, i);
            MessageBox.Show(correct ? "Correct!" : "Wrong!");
            ShowNextQuestion();
        }





    }
}

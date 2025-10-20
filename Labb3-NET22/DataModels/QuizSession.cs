using Labb3_NET22.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22.Controls
{
    public class QuizSession
    {
        private Quiz _quiz;
        private List<Question> _questions;
        private int _currentIndex = 0;

        public int CorrectAnswers { get; private set; }
        public int TotalAnswered { get; private set; }

        public QuizSession(Quiz quiz)
        {
            _quiz = quiz;

            _questions = quiz.Questions.OrderBy(q => Guid.NewGuid()).ToList();
        }


        public bool SubmitAnswer(Question question, int selectedAnswer)
        {
            TotalAnswered++;

            if(question.CorrectAnswer == selectedAnswer)
            {
                CorrectAnswers++;
                return true;
            }
            return false;
        }

        public Question GetNextQuestion()
        {
            if(_currentIndex >= _questions.Count)
            {
                return null;
            }
            return _questions[_currentIndex++];
        }
        public double GetScorePercent()
        {
            if (TotalAnswered == 0)
            {
                return 0;
            }
            return (double)CorrectAnswers / TotalAnswered * 100;
        }


        public bool IsFinished => _currentIndex >= _questions.Count;
    }
}

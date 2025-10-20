using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;
    private static Random _random = new Random();

    public Quiz(string title)
    {
        _questions = new List<Question>();
        _title = title;
    }

    public Question GetRandomQuestion()
    {
        List<Question> listOfQuestions = _questions.ToList();
        if(listOfQuestions.Count == 0)
        {
            return null;
        }

        int randomQuestion = _random.Next(listOfQuestions.Count);
        return listOfQuestions[randomQuestion];
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        List<Question>listOfQuestions = _questions.ToList();

        Question question = new Question(statement, answers, correctAnswer);
        listOfQuestions.Add(question);
        
        _questions = listOfQuestions;
    }

    public void RemoveQuestion(int index)
    {
        List<Question> listOfQuestions = _questions.ToList();
        if(index >=0 && index < listOfQuestions.Count)
        {
        listOfQuestions.RemoveAt(index);

        }
    }


}
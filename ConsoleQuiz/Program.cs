// See https://aka.ms/new-console-template for more information
using ConsoleQuiz;
//creating Dictionary for multiple choice question
    Dictionary<int, string> multipleChoice = new();
    multipleChoice.Add(1, "Paul");
    multipleChoice.Add(2, "Sonnie");
    multipleChoice.Add(3, "Kevin");
    multipleChoice.Add(4, "Tyler");
    string correctAnswer = "Kevin";
//creating multiple choice question object
MultipleChoice question1 = new("What is my name?", 1, multipleChoice, correctAnswer);
Console.WriteLine(question1.ToString());
//reading user input
string userAnswer = Console.ReadLine()!;
question1.setUserAnswer(userAnswer);
    if (question1.UserAnswer.ToLower() == question1.CorrectAnswer.ToLower())
    {
        Console.WriteLine("Correct!");
    }
    else
    {
        Console.WriteLine("Try again");
    }
//creating quiz object
Quiz quiz1 = new();
 quiz1.AddQuestion(question1);

using System.Reflection.Metadata.Ecma335;

namespace ConsoleQuiz; 

public class TF : Question
{
 
    List <string> Options { get; } = ["t", "f"];

    string CorrectAnswer { get; set; }
    string UserAnswer { get; set; }
 
    public TF (string prompt, string correctAnswer) : base(prompt)
    {
        CorrectAnswer = correctAnswer;
        Prompt = prompt;
    }
    public override void SetUserAnswer()
    {
        bool IsValidAnswer = false;
        do 
        {
            Console.WriteLine("Type in T or F.");
            UserAnswer = Console.ReadLine()!;
            if(UserAnswer.ToLower() == "f" || UserAnswer.ToLower() == "t")
            {
                IsValidAnswer = true;
            }
        }
        while(!IsValidAnswer);
    }
    public override void GradeQuestion()
    {
        if (UserAnswer.ToLower() == CorrectAnswer)
        {
            Correct = true;
        }
        else 
        {
            Correct = false;
        }
    }
    public override string ToString()
    {
        string nl = Environment.NewLine;
        return "Question " + QuestionNumber + nl + "True or False: " +
            Prompt + nl;
    }
}
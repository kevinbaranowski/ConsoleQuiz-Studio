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
    }
    public override void SetUserAnswer()
    {
        do 
        {
            Console.WriteLine("Type in T or F.");
            UserAnswer = Console.ReadLine()!;
        }
        while(UserAnswer.ToLower() != "f" || UserAnswer.ToLower() != "t" );
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
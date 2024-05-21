using System.Reflection.Metadata.Ecma335;

namespace ConsoleQuiz; 

public class TF : Question
{
 
    List <string> Options { get; } = ["true", "false"];

    string CorrectAnswer {get; set; }
    string UserAnswer { get; set; } = "";
    public TF (string prompt, int questionNumber, string correctAnswer) : base(prompt, questionNumber)
    {
        CorrectAnswer = correctAnswer;
    }

    
}
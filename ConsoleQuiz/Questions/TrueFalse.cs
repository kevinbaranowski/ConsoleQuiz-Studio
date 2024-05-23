using System.Reflection.Metadata.Ecma335;

namespace ConsoleQuiz; 

public class TF : Question
{
 
    List <string> Options { get; } = ["true", "false"];

    string CorrectAnswer { get; set; }
    string UserAnswer { get; set; } = "";
    public TF (string prompt, string correctAnswer) : base(prompt)
    {
        CorrectAnswer = correctAnswer;
    }
    public void SetUserAnswer(string userInput)
    {
        UserAnswer = userInput;
    }
}
using ConsoleQuiz;

namespace consoleQuiz {
public class Checkbox : Question
{
    Dictionary<int, string> Options { get; set; }
    List<string> UserAnswer { get; set; }
    List<string> CorrectAnswers {get; set; }
    public Checkbox(string prompt, int questionNumber, Dictionary<int,string> options, List<string> userAnswer, List<string> correctAnswers) : base(prompt, questionNumber)
    {
        Options = options;
        UserAnswer = userAnswer;
        CorrectAnswers = correctAnswers;
    }
    public override string ToString() 
    {
        String nl = Environment.NewLine;
        return "Question " + QuestionNumber + nl + 
            Options;
    }
}
}
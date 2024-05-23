using System.Text;
using ConsoleQuiz;

namespace ConsoleQuiz {
public class Checkbox : Question
{
    Dictionary<int, string> Options { get; set; }
    List<string> UserAnswers { get; set; } = [];
    Dictionary<int, string> CorrectAnswers { get; set; }
    public Checkbox(string prompt, Dictionary<int,string> options, Dictionary<int, string> correctAnswers) : base(prompt)
    {
        Options = options;
        CorrectAnswers = correctAnswers;
    }
    public override void SetUserAnswer()
    {
        List<string> userInput = [];
        bool condition = true;
        Console.WriteLine(@"This question takes multiple answers, enter one of your answers below and hit ENTER to continue to the next answer. 
        If you are done entering answers, hit ENTER before entering any characters.");
        while (condition)
        {
            string answer = Console.ReadLine()!;
            if (answer != "" && !userInput.Contains(answer))
            {
                userInput.Add(answer);
            }
            else
            {
                condition = false;
            }
        }
        UserAnswers = userInput;
    }
    
    public override void GradeQuestion()
    {
        bool IsAllCorrect = true;
        foreach (string userAnswer in UserAnswers)
        {
            if (!CorrectAnswers.ContainsKey(int.Parse(userAnswer)))
            {
                IsAllCorrect = false;
                break;
            }
        }
        Correct = IsAllCorrect;
    }

    public override string ToString() 
    {
        string nl = Environment.NewLine;
        StringBuilder optionsString = new();
        foreach (KeyValuePair<int, string> option in Options)
        {
            optionsString.Append(option.Key + ". " + option.Value);
            optionsString.Append(nl);
        }
        return "Question " + QuestionNumber + nl +
            Prompt + nl +
            optionsString;
    }
}
}
using System.Text;

namespace ConsoleQuiz;

public class MultipleChoice : Question
{
    public Dictionary<int, string> Options { get; set; }
    public string UserAnswer { get; set; }
    public Dictionary<int, string> CorrectAnswer { get; set; }

    public MultipleChoice(string prompt, Dictionary<int, string> options, Dictionary<int, string> correctAnswer) : base(prompt)
    {
        Options = options;
        CorrectAnswer = correctAnswer;
    }

    public override void SetUserAnswer()
    {
        Console.WriteLine("");
        string answer = Console.ReadLine()!;
        if (answer != "")
        {
            UserAnswer = answer;
        }
    
    }
    public override void GradeQuestion()
    {
        if (!CorrectAnswer.ContainsKey(int.Parse(UserAnswer)))
        {
            Correct = true;
        } 
        else {
            Correct = false;
        }
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
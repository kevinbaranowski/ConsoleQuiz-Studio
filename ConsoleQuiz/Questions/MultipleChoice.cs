using System.Text;

namespace ConsoleQuiz;

public class MultipleChoice : Question
{
    public Dictionary<int, string> Options { get; set; }
    public string UserAnswer { get; set; } = "";
    public string CorrectAnswer { get; set; }

    public MultipleChoice(string prompt, Dictionary<int, string> options, string correctAnswer) : base(prompt)
    {
        Options = options;
        CorrectAnswer = correctAnswer;
    }

    public void SetUserAnswer(string userInput)
    {
        UserAnswer = userInput;
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
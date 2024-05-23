namespace ConsoleQuiz;

public abstract class Question
{
    public string Prompt { get; set;}
    public int QuestionNumber { get; set; }

    public bool Correct { get; set; }

    public Question(string prompt)
    {
        Prompt = prompt;
    }
}
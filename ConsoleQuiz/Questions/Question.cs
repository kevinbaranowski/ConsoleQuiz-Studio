namespace ConsoleQuiz;

public abstract class Question
{
    public string Prompt { get; set;}
    public int QuestionNumber { get; set; }

    public Question(string prompt, int questionNumber)
    {
        Prompt = prompt;
        QuestionNumber = questionNumber;
    }
}
namespace ConsoleQuiz;

public class Quiz
{
    public List<Question> Questions = [];
    public double Score {get; set; }


    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    public void RunQuiz()
    {

    }
    
    public override string ToString()
    {
        string nl = Environment.NewLine;
        return "Here is your quiz!" + Questions.ToString();
    }
}
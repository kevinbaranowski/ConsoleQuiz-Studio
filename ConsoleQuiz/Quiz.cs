namespace ConsoleQuiz;

public class Quiz
{
    public string QuizName { get; set; }
    public List<Question> Questions = [];
    public double Score { get; set; }

    public Quiz(string quizName)
    {
        QuizName = quizName;
    }

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
        question.QuestionNumber = Questions.IndexOf(question) + 1;
    }

    public void ScoreQuiz()
    {
        double numberCorrect = 0;
        double numQuizQuestions = Questions.Count;
        foreach (Question question in Questions)
        {
            if (question.Correct)
            {
                numberCorrect++;
            }
        }
        Score = numberCorrect / numQuizQuestions;
        Console.WriteLine($"You earned a score of {numberCorrect} out of {numQuizQuestions}!");
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
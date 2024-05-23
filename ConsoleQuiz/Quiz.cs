namespace ConsoleQuiz;

public class Quiz
{
    public string? QuizName { get; set; }
    public List<Question> Questions = [];
    public double Score { get; set; }
    public void RunQuiz()
    {
        QuizCreation();
        foreach (Question question in Questions)
        {
            Console.WriteLine(question.ToString());
            question.SetUserAnswer();
            question.GradeQuestion();
            
        }
        ScoreQuiz();
    }
    
    public void QuizCreation()
    {
        NameQuiz();
        string? exitQuestionBuilder;
        do
        {
            Console.WriteLine(@"What kind of question would you like to add?
            Enter the corresponding number with the question type.
            1 - True/False
            2 - Multiple Choice
            3 - Checkbox (multiple answers)");
            string? questionType;
            while (true)
            {
                questionType = Console.ReadLine();
                if (questionType == "1" || questionType == "2" || questionType == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection.");
                }
            }
            if (questionType == "1")
            {
               TFValidation();
            }
            else if (questionType == "2")
            {
                MultipleChoiceValidation();
            }
            Console.WriteLine(@"If you are done creating questions for your quiz, press 'ENTER' to continue.
            If you would to create another question, press 'x'.");
            exitQuestionBuilder = Console.ReadLine();
        } while (exitQuestionBuilder == "x");
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
    public void NameQuiz()
    {
        Console.WriteLine(@"Welcome to Console Quiz Builder!
            Please enter a name for your quiz to get started.");
        while (true)
        {
            string quizName = Console.ReadLine()!;
            if (quizName != null && quizName != "")
            {
                
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid quiz name.");
            }
        }
    }
//validation methods and addition to quiz list
    public void TFValidation()
    {
         string prompt = AskQuestionPrompt();
                string? answer;
                while (true)
                {
                    Console.WriteLine("Please enter an answer for your question. Indicate 'T' for true, 'F' for false.");
                    answer = Console.ReadLine()!;
                    if (answer.ToLower() == "t" || answer.ToLower() == "f")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid answer for a true/false question.");
                    }
                }
                Question tf = new TF(prompt, answer);
                AddQuestion(tf);
    }
    public void MultipleChoiceValidation()
    {
        string? prompt = AskQuestionPrompt();
                Dictionary<int, string> options = new();
                Console.WriteLine("How many answer options would you like your question to have? Up to 5");
                int numOptions = int.Parse(Console.ReadLine()!);

                for (int i = 1; i < numOptions + 1; i++)
                {
                    Console.WriteLine($"Enter the answer option for option #{i}");
                    string? option = Console.ReadLine();
                    options.Add(i, option!);
                }
                Dictionary<int, string> correctAnswer = new();
                Console.WriteLine("Which option number is the correct answer?");
                int answer = int.Parse(Console.ReadLine()!);
                string value = options[answer];
                correctAnswer.Add(answer, value);

                Question multipleChoice = new MultipleChoice(prompt, options, correctAnswer);
                AddQuestion(multipleChoice);
    }
//utilized in question validations
    static string AskQuestionPrompt()
    {
        string? prompt;
            while (true)
            {
                Console.WriteLine("Please enter a prompt for your question.");
                prompt = Console.ReadLine()!;
                if (prompt.Length < 1)
                {
                    Console.WriteLine("You must enter at least one character for a question.");
                }
                else
                {
                    break;
                }
            }
        return prompt;    
    }   
    public override string ToString()
    {
        string nl = Environment.NewLine;
        return "Here is your quiz!" + Questions.ToString();
    }
}
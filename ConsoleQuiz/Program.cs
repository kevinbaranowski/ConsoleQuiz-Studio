using ConsoleQuiz;

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

Console.WriteLine(@"Welcome to Console Quiz Builder!
Please enter a name for your quiz to get started.");
Quiz quiz;
while (true)
{
    string? quizName = Console.ReadLine();
    if (quizName != null && quizName != "")
    {
        quiz = new(quizName);
        break;
    }
    else
    {
        Console.WriteLine("Please enter a valid quiz name.");
    }
}
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
        quiz.AddQuestion(tf);
    }
    else if (questionType == "2")
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
        quiz.AddQuestion(multipleChoice);
    }
    Console.WriteLine(@"If you are done creating questions for your quiz, press 'ENTER' to continue.
    If you would to create another question, press 'x'.");
    exitQuestionBuilder = Console.ReadLine();
} while (exitQuestionBuilder == "x");
foreach (Question question in quiz.Questions)
{
    question.ToString();
    question.SetUserAnswer();
    question.GradeQuestion();
    
}
quiz.ScoreQuiz();

    
// //creating Dictionary for multiple choice question
//     Dictionary<int, string> checkBoxOptions = new();
//     checkBoxOptions.Add(1, "Paul");
//     checkBoxOptions.Add(2, "Sonnie");
//     checkBoxOptions.Add(3, "Kevin");
//     checkBoxOptions.Add(4, "Tyler");
// //correct answer for question
//    Dictionary<int, string> correctAnswers = new();
//     correctAnswers.Add(2, "Sonnie");
//     correctAnswers.Add(3, "Kevin");

// //creating multiple choice question object
// Checkbox question1 = new("What are our names?", checkBoxOptions, correctAnswers);

//creating quiz object


// quiz.AddQuestion(question1);
// Console.WriteLine(question1.ToString());

// question1.CollectUserAnswers();
// question1.GradeQuestion();
// quiz.ScoreQuiz();
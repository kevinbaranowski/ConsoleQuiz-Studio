
using ConsoleQuiz;
//creating Dictionary for multiple choice question
    Dictionary<int, string> checkBoxOptions = new();
    checkBoxOptions.Add(1, "Paul");
    checkBoxOptions.Add(2, "Sonnie");
    checkBoxOptions.Add(3, "Kevin");
    checkBoxOptions.Add(4, "Tyler");

   Dictionary<int, string> correctAnswers = new();
    correctAnswers.Add(2, "Sonnie");
    correctAnswers.Add(3, "Kevin");

//creating multiple choice question object
Checkbox question1 = new("What are our names?", checkBoxOptions, correctAnswers);

//creating quiz object

Quiz quiz1 = new();
quiz1.AddQuestion(question1);
Console.WriteLine(question1.ToString());

question1.CollectUserAnswers();
question1.GradeQuestion();
quiz1.ScoreQuiz();



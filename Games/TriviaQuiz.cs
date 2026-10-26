namespace GamesConsole.Games;

public class TriviaQuiz : IGame
{
    private static readonly (string Question, string Answer)[] Questions =
    [
        ("What planet is known as the Red Planet?", "Mars"),
        ("How many sides does a hexagon have?", "6"),
        ("What is the largest ocean on Earth?", "Pacific"),
        ("What is the chemical symbol for gold?", "Au"),
        ("How many days are in a leap year?", "366"),
        ("What is the capital of Japan?", "Tokyo"),
        ("Which gas do plants absorb from the atmosphere?", "Carbon dioxide"),
        ("How many continents are there?", "7"),
        ("What is the smallest prime number?", "2"),
        ("Which animal is the tallest in the world?", "Giraffe"),
        ("What is the largest planet in our solar system?", "Jupiter"),
        ("How many colors are in a rainbow?", "7"),
        ("What is the hardest natural substance?", "Diamond"),
        ("Which country is home to the pyramids of Giza?", "Egypt"),
        ("What is the square root of 81?", "9"),
        ("Which language is primarily spoken in Brazil?", "Portuguese"),
        ("What is the name of the star at the center of our solar system?", "Sun"),
        ("How many legs does a spider have?", "8"),
        ("What is the freezing point of water in Celsius?", "0"),
        ("Which instrument has keys, pedals, and strings?", "Piano")
    ];

    public void PlayGame()
    {
        int score = 0;
        var questions = Questions.ToArray();
        Random.Shared.Shuffle(questions);
        const int questionCount = 5;

        Console.WriteLine("Trivia Quiz");

        for (int i = 0; i < questionCount; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].Question}");
            Console.Write("Your answer: ");
            string? answer = Console.ReadLine();
            if (answer is null)
            {
                return;
            }

            if (string.Equals(answer.Trim(), questions[i].Answer, StringComparison.OrdinalIgnoreCase))
            {
                score++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Not quite. The answer is {questions[i].Answer}.");
            }
        }

        Console.WriteLine($"Quiz complete! You scored {score} out of {questionCount}.");
    }
}

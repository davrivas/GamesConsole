namespace GamesConsole.Games;

public class MathChallenge : IGame
{
    private const int QuestionCount = 5;

    public void PlayGame()
    {
        int score = 0;
        Console.WriteLine($"Math Challenge: solve {QuestionCount} problems.");

        for (int question = 1; question <= QuestionCount; question++)
        {
            int first = Random.Shared.Next(1, 13);
            int second = Random.Shared.Next(1, 13);
            char operation = "+-*"[Random.Shared.Next(3)];
            int answer = operation switch
            {
                '+' => first + second,
                '-' => first - second,
                _ => first * second
            };

            Console.Write($"{question}. What is {first} {operation} {second}? ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            if (int.TryParse(input, out int guess) && guess == answer)
            {
                score++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"The answer is {answer}.");
            }
        }

        Console.WriteLine($"Challenge complete! You scored {score} out of {QuestionCount}.");
    }
}

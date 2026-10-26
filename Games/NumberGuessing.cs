namespace GamesConsole.Games;

public class NumberGuessing : IGame
{
    private const int MinimumNumber = 1;
    private const int MaximumNumber = 100;
    private const int MaximumAttempts = 7;

    public void PlayGame()
    {
        int numberToGuess = Random.Shared.Next(MinimumNumber, MaximumNumber + 1);

        Console.WriteLine($"Number Guessing: guess a number from {MinimumNumber} to {MaximumNumber}.");

        for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
        {
            Console.Write($"Attempt {attempt}/{MaximumAttempts}: ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            if (!int.TryParse(input, out int guess) || guess < MinimumNumber || guess > MaximumNumber)
            {
                Console.WriteLine($"Enter a whole number from {MinimumNumber} to {MaximumNumber}.");
                attempt--;
                continue;
            }

            if (guess == numberToGuess)
            {
                Console.WriteLine("Correct! You guessed the number.");
                return;
            }

            Console.WriteLine(guess < numberToGuess ? "Too low." : "Too high.");
        }

        Console.WriteLine($"Out of attempts! The number was {numberToGuess}.");
    }
}

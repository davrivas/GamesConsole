namespace GamesConsole.Games;

public class Mastermind : IGame
{
    private const int CodeLength = 4;
    private const int MaximumAttempts = 10;
    private const string AvailableDigits = "123456";

    public void PlayGame()
    {
        char[] code = AvailableDigits.ToCharArray();
        Random.Shared.Shuffle(code);
        code = code[..CodeLength];

        Console.WriteLine($"Mastermind: guess the {CodeLength}-digit code using digits 1-6 without repeats.");

        for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
        {
            Console.Write($"Attempt {attempt}/{MaximumAttempts}: ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            string guess = input.Trim();
            if (!IsValidGuess(guess))
            {
                Console.WriteLine("Enter four different digits from 1 to 6.");
                attempt--;
                continue;
            }

            int exactMatches = 0;
            int misplacedMatches = 0;
            for (int i = 0; i < CodeLength; i++)
            {
                if (guess[i] == code[i])
                {
                    exactMatches++;
                }
                else if (code.Contains(guess[i]))
                {
                    misplacedMatches++;
                }
            }

            if (exactMatches == CodeLength)
            {
                Console.WriteLine("You cracked the code!");
                return;
            }

            Console.WriteLine($"Exact matches: {exactMatches}. Misplaced matches: {misplacedMatches}.");
        }

        Console.WriteLine($"Out of attempts! The code was {new string(code)}.");
    }

    private static bool IsValidGuess(string guess)
    {
        return guess.Length == CodeLength &&
               guess.All(AvailableDigits.Contains) &&
               guess.Distinct().Count() == CodeLength;
    }
}

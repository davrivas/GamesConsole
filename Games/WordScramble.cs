namespace GamesConsole.Games;

public class WordScramble : IGame
{
    private static readonly string[] Words =
    [
        "planet",
        "puzzle",
        "guitar",
        "forest",
        "castle",
        "rocket",
        "garden",
        "silver",
        "window",
        "dragon"
    ];

    public void PlayGame()
    {
        string word = Words[Random.Shared.Next(Words.Length)];
        char[] scrambledLetters = word.ToCharArray();

        Random.Shared.Shuffle(scrambledLetters);
        if (new string(scrambledLetters) == word)
        {
            Array.Reverse(scrambledLetters);
        }

        Console.WriteLine($"Word Scramble: unscramble '{new string(scrambledLetters)}'.");
        Console.Write("Your guess: ");
        string? guess = Console.ReadLine();
        if (guess is null)
        {
            return;
        }

        if (string.Equals(guess.Trim(), word, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Not quite. The word was {word}.");
        }
    }
}

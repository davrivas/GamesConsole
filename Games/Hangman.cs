namespace GamesConsole.Games;

public class Hangman : IGame
{
    private readonly List<string> _words = [
        "apple",
        "bridge",
        "candle",
        "castle",
        "cloud",
        "dragon",
        "forest",
        "guitar",
        "island",
        "jungle",
        "kitten",
        "lantern",
        "mountain",
        "ocean",
        "puzzle",
        "rocket",
        "sunshine",
        "thunder",
        "volcano",
        "whisper"
    ];
    private readonly string _wordToGuess;

    public Hangman()
    {
        _wordToGuess = _words[Random.Shared.Next(_words.Count)];
    }

    public void PlayGame()
    {
        int attemptsLeft = _wordToGuess.Length + 3;
        var guessedLetters = new HashSet<char>();
        char[] displayWord = new string('_', _wordToGuess.Length).ToCharArray();

        while (attemptsLeft > 0 && new string(displayWord) != _wordToGuess)
        {
            Console.WriteLine($"Word: {new string(displayWord)}");
            Console.WriteLine($"Attempts left: {attemptsLeft}");
            Console.Write("Guess a letter: ");
            char guess = (Console.ReadLine() ?? string.Empty).ToLower()[0];

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
                continue;
            }

            guessedLetters.Add(guess);

            if (_wordToGuess.Contains(guess))
            {
                for (int i = 0; i < _wordToGuess.Length; i++)
                {
                    if (_wordToGuess[i] == guess)
                    {
                        displayWord[i] = guess;
                    }
                }
            }
            else
            {
                attemptsLeft--;
                Console.WriteLine("Incorrect guess.");
            }
        }

        if (new string(displayWord) == _wordToGuess)
        {
            Console.WriteLine($"Congratulations! You guessed the word: {_wordToGuess}");
        }
        else
        {
            Console.WriteLine($"Game over! The word was: {_wordToGuess}");
        }
    }
}
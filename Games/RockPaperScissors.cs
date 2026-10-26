namespace GamesConsole.Games;

public class RockPaperScissors : IGame
{
    private static readonly string[] Choices = ["rock", "paper", "scissors"];
    private const int WinsNeeded = 3;

    public void PlayGame()
    {
        int playerScore = 0;
        int computerScore = 0;

        Console.WriteLine($"Rock, Paper, Scissors: first to {WinsNeeded} wins.");

        while (playerScore < WinsNeeded && computerScore < WinsNeeded)
        {
            Console.Write("Choose rock, paper, or scissors: ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            string playerChoice = input.Trim().ToLowerInvariant();
            if (!Choices.Contains(playerChoice))
            {
                Console.WriteLine("Please enter rock, paper, or scissors.");
                continue;
            }

            string computerChoice = Choices[Random.Shared.Next(Choices.Length)];
            Console.WriteLine($"Computer chose {computerChoice}.");

            if (playerChoice == computerChoice)
            {
                Console.WriteLine("It's a tie.");
            }
            else if (Beats(playerChoice, computerChoice))
            {
                playerScore++;
                Console.WriteLine("You win this round.");
            }
            else
            {
                computerScore++;
                Console.WriteLine("Computer wins this round.");
            }

            Console.WriteLine($"Score: You {playerScore} - {computerScore} Computer");
        }

        Console.WriteLine(playerScore == WinsNeeded ? "You won the game!" : "Computer won the game.");
    }

    private static bool Beats(string first, string second)
    {
        return (first == "rock" && second == "scissors") ||
               (first == "paper" && second == "rock") ||
               (first == "scissors" && second == "paper");
    }
}

namespace GamesConsole.Games;

public class Pig : IGame
{
    private const int WinningScore = 50;

    public void PlayGame()
    {
        int playerScore = 0;
        int computerScore = 0;
        Console.WriteLine($"Pig: first to {WinningScore} points wins. Roll or hold each turn.");

        while (playerScore < WinningScore && computerScore < WinningScore)
        {
            int turnScore = 0;
            while (true)
            {
                Console.Write($"Your score: {playerScore}, turn points: {turnScore}. (r)oll or (h)old? ");
                string? input = Console.ReadLine();
                if (input is null)
                {
                    return;
                }

                string choice = input.Trim().ToLowerInvariant();
                if (choice == "h" || choice == "hold")
                {
                    playerScore += turnScore;
                    Console.WriteLine($"You hold. Your total is {playerScore}.");
                    break;
                }

                if (choice != "r" && choice != "roll")
                {
                    Console.WriteLine("Enter 'r' to roll or 'h' to hold.");
                    continue;
                }

                int roll = Random.Shared.Next(1, 7);
                Console.WriteLine($"You rolled {roll}.");
                if (roll == 1)
                {
                    turnScore = 0;
                    Console.WriteLine("Your turn points are lost.");
                    break;
                }

                turnScore += roll;
                if (playerScore + turnScore >= WinningScore)
                {
                    playerScore += turnScore;
                    break;
                }
            }

            if (playerScore >= WinningScore)
            {
                break;
            }

            int computerTurnScore = 0;
            while (computerTurnScore < 20)
            {
                int roll = Random.Shared.Next(1, 7);
                Console.WriteLine($"Computer rolled {roll}.");
                if (roll == 1)
                {
                    computerTurnScore = 0;
                    break;
                }

                computerTurnScore += roll;
                if (computerScore + computerTurnScore >= WinningScore)
                {
                    break;
                }
            }

            computerScore += computerTurnScore;
            Console.WriteLine($"Computer holds with {computerTurnScore} points. Score: You {playerScore} - {computerScore} Computer");
        }

        Console.WriteLine(playerScore >= WinningScore ? "You win!" : "The computer wins!");
    }
}

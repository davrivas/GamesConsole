using GamesConsole.Games;

while (true)
{

    Console.WriteLine("Games:");
    Console.WriteLine("1. Hangman");
    Console.WriteLine("2. Tic Tac Toe");
    Console.WriteLine("3. Number Guessing");
    Console.WriteLine("4. Rock, Paper, Scissors");
    Console.WriteLine("5. Trivia Quiz");
    Console.WriteLine("6. Word Scramble");
    Console.WriteLine("7. Math Challenge");
    Console.WriteLine("8. Mastermind");
    Console.WriteLine("9. Pig");
    Console.WriteLine("10. Connect Four");
    Console.WriteLine("0. Quit");
    string? input = Console.ReadLine();
    if (input is null)
    {
        Console.WriteLine("Invalid input. Please try again.");
        continue;
    }

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Please enter a number from 0 to 10.");
        continue;
    }

    if (choice == 0)
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    IGame? game = choice switch
    {
        1 => new Hangman(),
        2 => new TicTacToe(),
        3 => new NumberGuessing(),
        4 => new RockPaperScissors(),
        5 => new TriviaQuiz(),
        6 => new WordScramble(),
        7 => new MathChallenge(),
        8 => new Mastermind(),
        9 => new Pig(),
        10 => new ConnectFour(),
        _ => null
    };
    
    if (game is null)
    {
        Console.WriteLine("Invalid choice. Please select a game from 1 to 10.");
        continue;
    }

    game.PlayGame();
}
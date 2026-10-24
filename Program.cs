using GamesConsole.Games;

while (true)
{

    Console.WriteLine("Games:");
    Console.WriteLine("1. Hangman");
    Console.WriteLine("2. Tic Tac Toe");
    Console.WriteLine("0. Quit");
    int choice = Convert.ToInt32(Console.ReadLine());

    IGame? game = choice switch
    {
        1 => new Hangman(),
        2 => new TicTacToe(),
        0 => null,
        _ => throw new ArgumentOutOfRangeException(nameof(choice), "Invalid choice. Please select a valid option.")
    };

    if (game is null) return;

    game.PlayGame();
}
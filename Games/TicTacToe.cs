namespace GamesConsole.Games;

public class TicTacToe : IGame
{
    public void PlayGame()
    {
        char[] board = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];
        char currentPlayer = 'X';

        Console.WriteLine("Tic Tac Toe");

        while (true)
        {
            DisplayBoard(board);
            Console.Write($"Player {currentPlayer}, choose a cell (1-9): ");

            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            if (!int.TryParse(input, out int cell) || cell < 1 || cell > board.Length)
            {
                Console.WriteLine("Please enter a number from 1 to 9.");
                continue;
            }

            if (board[cell - 1] != ' ')
            {
                Console.WriteLine("That cell is already occupied. Choose another one.");
                continue;
            }

            board[cell - 1] = currentPlayer;

            if (HasWon(board, currentPlayer))
            {
                DisplayBoard(board);
                Console.WriteLine($"Player {currentPlayer} wins!");
                return;
            }

            if (Array.TrueForAll(board, mark => mark != ' '))
            {
                DisplayBoard(board);
                Console.WriteLine("It's a draw!");
                return;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

    private static void DisplayBoard(char[] board)
    {
        char Cell(int index) => board[index] == ' ' ? (char)('1' + index) : board[index];

        Console.WriteLine();
        Console.WriteLine($" {Cell(0)} | {Cell(1)} | {Cell(2)}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cell(3)} | {Cell(4)} | {Cell(5)}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cell(6)} | {Cell(7)} | {Cell(8)}");
        Console.WriteLine();
    }

    private static bool HasWon(char[] board, char player)
    {
        return
            (board[0] == player && board[1] == player && board[2] == player) ||
            (board[3] == player && board[4] == player && board[5] == player) ||
            (board[6] == player && board[7] == player && board[8] == player) ||
            (board[0] == player && board[3] == player && board[6] == player) ||
            (board[1] == player && board[4] == player && board[7] == player) ||
            (board[2] == player && board[5] == player && board[8] == player) ||
            (board[0] == player && board[4] == player && board[8] == player) ||
            (board[2] == player && board[4] == player && board[6] == player);
    }
}
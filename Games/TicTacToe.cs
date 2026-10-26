namespace GamesConsole.Games;

public class TicTacToe : IGame
{
    private const char HumanPlayer = 'X';
    private const char ComputerPlayer = 'O';

    public void PlayGame()
    {
        char[] board = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];

        Console.WriteLine("Tic Tac Toe - You are X, the computer is O.");

        while (true)
        {
            DisplayBoard(board);
            Console.Write("Choose a cell (1-9): ");

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

            board[cell - 1] = HumanPlayer;

            if (HasWon(board, HumanPlayer))
            {
                DisplayBoard(board);
                Console.WriteLine("You win!");
                return;
            }

            if (IsBoardFull(board))
            {
                DisplayBoard(board);
                Console.WriteLine("It's a draw!");
                return;
            }

            int computerMove = ChooseComputerMove(board);
            board[computerMove] = ComputerPlayer;
            Console.WriteLine($"The computer chooses cell {computerMove + 1}.");

            if (HasWon(board, ComputerPlayer))
            {
                DisplayBoard(board);
                Console.WriteLine("The computer wins!");
                return;
            }

            if (IsBoardFull(board))
            {
                DisplayBoard(board);
                Console.WriteLine("It's a draw!");
                return;
            }
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

    private static bool IsBoardFull(char[] board)
    {
        return Array.TrueForAll(board, mark => mark != ' ');
    }

    private static int ChooseComputerMove(char[] board)
    {
        int bestScore = int.MinValue;
        List<int> bestMoves = [];

        for (int cell = 0; cell < board.Length; cell++)
        {
            if (board[cell] != ' ')
            {
                continue;
            }

            board[cell] = ComputerPlayer;
            int score = GetMinimaxScore(board, isComputerTurn: false, depth: 1);
            board[cell] = ' ';

            if (score > bestScore)
            {
                bestScore = score;
                bestMoves.Clear();
                bestMoves.Add(cell);
            }
            else if (score == bestScore)
            {
                bestMoves.Add(cell);
            }
        }

        return bestMoves[Random.Shared.Next(bestMoves.Count)];
    }

    private static int GetMinimaxScore(char[] board, bool isComputerTurn, int depth)
    {
        if (HasWon(board, ComputerPlayer))
        {
            return 10 - depth;
        }

        if (HasWon(board, HumanPlayer))
        {
            return depth - 10;
        }

        if (IsBoardFull(board))
        {
            return 0;
        }

        int bestScore = isComputerTurn ? int.MinValue : int.MaxValue;
        char currentPlayer = isComputerTurn ? ComputerPlayer : HumanPlayer;

        for (int cell = 0; cell < board.Length; cell++)
        {
            if (board[cell] != ' ')
            {
                continue;
            }

            board[cell] = currentPlayer;
            int score = GetMinimaxScore(board, !isComputerTurn, depth + 1);
            board[cell] = ' ';

            bestScore = isComputerTurn
                ? Math.Max(bestScore, score)
                : Math.Min(bestScore, score);
        }

        return bestScore;
    }
}
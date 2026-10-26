namespace GamesConsole.Games;

public class ConnectFour : IGame
{
    private const int RowCount = 6;
    private const int ColumnCount = 7;
    private const char HumanPlayer = 'X';
    private const char ComputerPlayer = 'O';

    public void PlayGame()
    {
        char[,] board = new char[RowCount, ColumnCount];
        Console.WriteLine("Connect Four: get four in a row. You are X; the computer is O.");

        while (true)
        {
            DisplayBoard(board);
            Console.Write("Choose a column (1-7): ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                return;
            }

            if (!int.TryParse(input, out int column) || column < 1 || column > ColumnCount)
            {
                Console.WriteLine("Please enter a column from 1 to 7.");
                continue;
            }

            int row = GetOpenRow(board, column - 1);
            if (row < 0)
            {
                Console.WriteLine("That column is full. Choose another one.");
                continue;
            }

            board[row, column - 1] = HumanPlayer;
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

            int computerColumn = ChooseComputerColumn(board);
            int computerRow = GetOpenRow(board, computerColumn);
            board[computerRow, computerColumn] = ComputerPlayer;
            Console.WriteLine($"The computer chooses column {computerColumn + 1}.");

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

    private static void DisplayBoard(char[,] board)
    {
        Console.WriteLine();
        for (int row = 0; row < RowCount; row++)
        {
            for (int column = 0; column < ColumnCount; column++)
            {
                char cell = board[row, column] == '\0' ? '.' : board[row, column];
                Console.Write($" {cell}");
            }

            Console.WriteLine();
        }

        Console.WriteLine(" 1 2 3 4 5 6 7");
        Console.WriteLine();
    }

    private static int GetOpenRow(char[,] board, int column)
    {
        for (int row = RowCount - 1; row >= 0; row--)
        {
            if (board[row, column] == '\0')
            {
                return row;
            }
        }

        return -1;
    }

    private static int ChooseComputerColumn(char[,] board)
    {
        List<int> validColumns = [];
        for (int column = 0; column < ColumnCount; column++)
        {
            if (GetOpenRow(board, column) >= 0)
            {
                validColumns.Add(column);
            }
        }

        foreach (char player in new[] { ComputerPlayer, HumanPlayer })
        {
            foreach (int column in validColumns)
            {
                int row = GetOpenRow(board, column);
                board[row, column] = player;
                bool wins = HasWon(board, player);
                board[row, column] = '\0';
                if (wins)
                {
                    return column;
                }
            }
        }

        return validColumns[Random.Shared.Next(validColumns.Count)];
    }

    private static bool HasWon(char[,] board, char player)
    {
        int[] rowDirections = [0, 1, 1, 1];
        int[] columnDirections = [1, 0, 1, -1];

        for (int row = 0; row < RowCount; row++)
        {
            for (int column = 0; column < ColumnCount; column++)
            {
                if (board[row, column] != player)
                {
                    continue;
                }

                for (int direction = 0; direction < rowDirections.Length; direction++)
                {
                    int endRow = row + 3 * rowDirections[direction];
                    int endColumn = column + 3 * columnDirections[direction];
                    if (endRow < 0 || endRow >= RowCount || endColumn < 0 || endColumn >= ColumnCount)
                    {
                        continue;
                    }

                    bool fourInARow = true;
                    for (int step = 1; step < 4; step++)
                    {
                        if (board[row + step * rowDirections[direction], column + step * columnDirections[direction]] != player)
                        {
                            fourInARow = false;
                            break;
                        }
                    }

                    if (fourInARow)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private static bool IsBoardFull(char[,] board)
    {
        for (int column = 0; column < ColumnCount; column++)
        {
            if (board[0, column] == '\0')
            {
                return false;
            }
        }

        return true;
    }
}

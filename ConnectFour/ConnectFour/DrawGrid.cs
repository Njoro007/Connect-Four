using ConnectFour;

public class DrawGrid
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public Disc[,] Grid { get; private set; }

    private GameInventory inventory;

    public DrawGrid(int rows, int columns, GameInventory gameInventory)
    {
        Rows = rows;
        Columns = columns;
        Grid = new Disc[rows, columns];
        inventory = gameInventory;
    }

    //determines how far a disc will fall in a given column — i.e., the lowest available row.
    public int GetDropRow(int column)
    {
        if (column < 0 || column >= Columns)
            throw new ArgumentOutOfRangeException(nameof(column), "Column index out of bounds.");

        for (int row = 0; row < Rows; row++)
        {
            if (Grid[row, column] == null)
                return row;
        }

        return -1; // Column is full
    }


    //This method takes the disc symbol, player number, and column, then places the disc if possible.
    public bool PlaceDisc(char symbol, int player, int column)
    {
        int dropRow = GetDropRow(column);

        if (dropRow == -1)
        {
            Console.WriteLine("❌ Column is full.");
            return false;
        }

        // Validate disc availability
        if (!inventory.IsDiscAvailable(player, symbol))
        {
            Console.WriteLine("❌ No remaining discs of that type.");
            return false;
        }

        // Create disc and place it
        Disc disc = Disc.CreateDiscFromSymbol(symbol);
        Grid[dropRow, column] = disc;

        // Decrement inventory
        string discType = Disc.GetDiscTypeFromSymbol(symbol);
        inventory.UseDisc(inventory.moveCounter, discType);

        return true;
    }


    public void DisplayGrid(int moveCounter)
    {
        Console.Clear();
        Console.WriteLine();

        string currentPlayer = moveCounter % 2 != 0 ? "Player 1" : "Player 2";
        string symbol = currentPlayer == "Player 1" ? inventory.PlayerOneName : inventory.PlayerTwoName;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Move #{moveCounter} — {currentPlayer}'s turn ({symbol})");
        Console.ResetColor();
        Console.WriteLine();

        for (int row = Rows - 1; row >= 0; row--)
        {
            Console.Write($"{row + 1,2} ");
            for (int col = 0; col < Columns; col++)
            {
                Disc disc = Grid[row, col];
                char cellSymbol = disc?.Symbol ?? ' ';
                Console.Write($"| {cellSymbol} ");
            }
            Console.WriteLine("|");
        }

        Console.Write("   ");
        for (int col = 0; col < Columns; col++)
        {
            Console.Write($"  {col + 1} ");
        }

        Console.WriteLine("\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Disc Inventory:");
        Console.WriteLine($"Player 1 ({inventory.PlayerOneName}) → Ordinary: {inventory.PlayerOneOrdinaryDiscs}, Boring: {inventory.PlayerOneBoringDiscs}, Magnetic: {inventory.PlayerOneMagneticDiscs}");
        Console.WriteLine($"Player 2 ({inventory.PlayerTwoName}) → Ordinary: {inventory.PlayerTwoOrdinaryDiscs}, Boring: {inventory.PlayerTwoBoringDiscs}, Magnetic: {inventory.PlayerTwoMagneticDiscs}");
        Console.ResetColor();

        Console.WriteLine();
    }
}
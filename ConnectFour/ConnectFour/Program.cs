using System.Numerics;

namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ConnectFour - IFN584 Edition";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==============================================");
            Console.WriteLine("Welcome to ConnectFour!");
            Console.WriteLine("Developed by Philip Njoroge for IFN584");
            Console.WriteLine("==============================================");

            Console.WriteLine("Select Game Mode:");
            Console.WriteLine("1. Human vs Human");
            Console.WriteLine("2. Human vs Computer");
            Console.WriteLine("3. Restore Saved Game");
            Console.WriteLine("4. Test Mode");

           
            int mode = InputValidation.GetValidatedInteger("Enter your choice (1-4): ", 1, 4);

            GameInventory gameInventory = new GameInventory();

            switch (mode)
            {
                case 1:
                    gameInventory.GameMode = "Human vs Human";
                    break;
                case 2:
                    gameInventory.GameMode = "Human vs Computer";
                    break;
                case 3:
                    gameInventory.GameMode = "Restore Saved Game";
                    break;
                case 4:
                    gameInventory.GameMode = "Test Mode";
                    break;
            }

            if (mode == 3)
            {
                // Load from file
                // Later
            }
            else if (mode == 4)
            {
                // Paste String
                // Later
            }
            else
            {
                // Setup for new game
                gameInventory.Rows = InputValidation.GetValidatedInteger("Enter number of rows: ", 4, 10);
                gameInventory.Columns = InputValidation.ComputeColumnsFromRows(gameInventory.Rows);

                // Set player symbols as per assignment
                gameInventory.PlayerOneName = "@";
                gameInventory.PlayerTwoName = "#";

                // Initialize disc counts
                gameInventory.InitializeDiscInventory();
                gameInventory.DisplaySummary();
                gameInventory.DisplayDiscSummary();

                DrawGrid grid = new DrawGrid(gameInventory.Rows, gameInventory.Columns, gameInventory);

                gameInventory.moveCounter = 1;
                grid.DisplayGrid(gameInventory.moveCounter);

                while (true)
                {
                    Console.Write("Enter move (e.g. o3, M4 or b7): ");
                    string input = Console.ReadLine();

                    try
                    {
                        var (disc, column) = InputValidation.ParseInput(input, gameInventory.moveCounter, gameInventory, gameInventory.Columns);
                        int player = gameInventory.moveCounter % 2 != 0 ? 1 : 2;

                        int dropRow = grid.PlaceDisc(disc.Symbol, player, column);

                        if (dropRow != -1) // -1 indicates failure
                        {
                            gameInventory.moveCounter++;
                            grid.DisplayGrid(gameInventory.moveCounter);

                            // Check for win
                            bool isWinningMove = grid.CheckWin(dropRow, column);
                            if (isWinningMove)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                string winner = player == 1 ? gameInventory.PlayerOneName : gameInventory.PlayerTwoName;
                                Console.WriteLine($"****{winner} wins the game!****");
                                Console.ResetColor();
                                break;
                            }

                            // Check for draw
                            bool isDraw = grid.CheckDraw();
                            if (isDraw)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("It's a draw! No more moves left.");
                                Console.ResetColor();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Move not successful. Try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

        }
    }
}

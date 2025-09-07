namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ConnectFour - IFN584 Edition";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==============================================");
            Console.WriteLine("🎮 Welcome to ConnectFour!");
            Console.WriteLine("🧠 Developed by Philip Njoroge for IFN584");
            Console.WriteLine("==============================================\n");

            Console.WriteLine("Select Game Mode:");
            Console.WriteLine("1. Human vs Human");
            Console.WriteLine("2. Human vs Computer");
            Console.WriteLine("3. Restore Saved Game");
            Console.WriteLine("4. ✅ Test Mode");

            int mode;
            while (true)
            {
                try
                {
                    mode = InputValidation.GetValidatedInteger("Enter your choice (1-4): ", 1, 4);
                    Console.WriteLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Invalid input: {ex.Message}. Please try again.\n");
                }
            }

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
                // 🔄 Load from file
                
            }
            else
            {
                // 🧩 Setup for new game
                gameInventory.Rows = InputValidation.GetValidatedInteger("Enter number of rows: ", 4, 10);
                gameInventory.Columns = InputValidation.ComputeColumnsFromRows(gameInventory.Rows);

                // 🎯 Set player symbols as per assignment
                gameInventory.PlayerOneName = "@";
                gameInventory.PlayerTwoName = "#";

                gameInventory.DisplaySummary();

            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class GameInventory
    {
        public string GameMode { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

        public void DisplaySummary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("📋 Game Summary:");
            Console.WriteLine($"Mode: {GameMode}");
            Console.WriteLine($"Grid Size: {Rows} rows × {Columns} columns");
            Console.WriteLine($"Player 1: {PlayerOneName}");
            Console.WriteLine($"Player 2: {PlayerTwoName}");
            Console.WriteLine();

            Console.ResetColor();
            Thread.Sleep(1500); // Pause for 1.5 seconds
        }


    }
}

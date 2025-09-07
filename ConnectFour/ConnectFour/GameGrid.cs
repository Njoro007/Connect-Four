using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class GameGrid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Disc[,] Grid { get; private set; }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new Disc[rows, columns];
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(); // Optional spacing

            for (int row = Rows - 1; row >= 0; row--) // Top to bottom visually
            {
                for (int col = 0; col < Columns; col++)
                {
                    Disc disc = Grid[row, col];
                    char symbol = disc?.Symbol ?? ' ';
                    Console.Write($"| {symbol} ");
                }
                Console.WriteLine("|");
            }

            // Optional: Column numbers for reference
            for (int col = 0; col < Columns; col++)
            {
                Console.Write($"  {col + 1} ");
            }
            Console.WriteLine("\n");
        }
    }
}

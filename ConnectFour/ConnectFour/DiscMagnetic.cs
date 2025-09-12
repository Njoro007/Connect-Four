using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class DiscMagnetic : Disc
    {
        public DiscMagnetic(char symbol) : base(symbol) { }

        public override void ApplyEffect(Disc[,] grid, int row, int col, GameInventory inventory)
        {
            int player = Symbol == 'M' ? 1 : 2;
            char ordinarySymbol = player == 1 ? '@' : '#';

            for (int r = row + 1; r < grid.GetLength(0); r++)
            {
                Disc target = grid[r, col];
                if (target != null && target.Symbol == ordinarySymbol)
                {
                    if (r == row + 1) break; // Directly below — no lift

                    grid[r - 1, col] = target; // Lift up
                    grid[r, col] = null;
                    break; // Only one disc affected
                }
            }

            // Convert magnetic disc to ordinary
            grid[row, col] = new DiscOrdinary(ordinarySymbol);
        }


    }
}
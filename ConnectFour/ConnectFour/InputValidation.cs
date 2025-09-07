using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class InputValidation
    {
        public static int GetValidatedInteger(string prompt, int min, int max)
        {
            int result;
            Console.Write(prompt);
            string input = Console.ReadLine();

            while (!int.TryParse(input, out result) || result < min || result > max)
            {
                Console.Write($"Invalid input. Please enter a number between {min} and {max}: ");
                input = Console.ReadLine();
            }

            return result;
        }


        public static int ComputeColumnsFromRows(int rows)
        {
            return (int)Math.Round(rows * (7.0 / 6.0));
        }
    }
}

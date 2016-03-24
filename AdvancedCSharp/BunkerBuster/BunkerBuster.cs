using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunkerBuster
{
    class BunkerBuster
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int colls = int.Parse(dimensions[1]);
            int[,] matrix = new int[rows, colls];

            for (int row = 0; row < rows; row++)
            {
                string[] elements = Console.ReadLine().Split();
                int[] intElements = Array.ConvertAll(elements, int.Parse);

                for (int coll = 0; coll < colls; coll++)
                {
                    matrix[row, coll] = intElements[coll];
                }
            }

            string input = Console.ReadLine();
            while (input != "cease fire!")
            {
                string[] elements = input.Split();
                int row = int.Parse(elements[0]);
                int coll = int.Parse(elements[1]);
                int power = char.Parse(elements[2]);
                double halfPower = Math.Round(power / 2.0);

                int startRow = Math.Max(0, row - 1);
                int endRow = Math.Min(rows, row + 1);
                int startColl = Math.Max(0, coll - 1);
                int endColl = Math.Min(coll + 1, colls);

                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startColl; j <= endColl; j++)
                    {
                        if (i == row && j == coll)
                        {
                            matrix[i, j] -= power;
                        }
                        else
                        {
                            matrix[i, j] -= (int)halfPower;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colls; j++)
                {
                    int currentNumber = matrix[i, j];
                    if (currentNumber <= 0)
                    {
                        counter++;

                    }

                }
            }

            double totalCells = (double)rows*colls;
            double percentDestroyed = (counter/totalCells) * 100;
            Console.WriteLine("Destroyed bunkers: {0}",counter);
            Console.WriteLine("Damage done: {0:F1} %",percentDestroyed);


        }
    }
}

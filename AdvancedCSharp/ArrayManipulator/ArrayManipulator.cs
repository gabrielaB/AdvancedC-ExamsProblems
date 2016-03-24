using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            string[] numbersArray = Console.ReadLine().Split();
            string command = Console.ReadLine();
            int[] numbers = Array.ConvertAll(numbersArray, int.Parse);
            int[] outputArray = numbers;

            while (command != "end")
            {
                string[] parameters = command.Split();
                string commandName = parameters[0];

                switch (commandName)
                {
                    case "exchange":
                        {
                            int index = int.Parse(parameters[1]);
                            if (index < 0 || index > numbers.Length)
                            {
                                Console.WriteLine("Invalid index");
                                continue;
                            }
                            outputArray = Exchange(outputArray, index);
                            //Console.WriteLine("[" + string.Join(", ", outputArray) + "]");
                        }
                        break;
                    case "max":
                    case "min":
                        {
                            string oddOrEven = parameters[1];
                            string maxOrMin = MaxOrMin(outputArray, commandName, oddOrEven);
                            Console.WriteLine(maxOrMin);
                        }
                        break;
                    case "first":
                    case "last":
                        {
                            int count = int.Parse(parameters[1]);
                            if (count > numbers.Length)
                            {
                                Console.WriteLine("Invalid count");
                                continue;
                            }
                            string oddOrEven = parameters[2];
                            FirstOrLast(outputArray, commandName, count, oddOrEven);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ",outputArray) + "]");
            
        }

        private static void FirstOrLast(int[] numbers, string commandName, int count, string oddOrEven)
        {
            int reminder = oddOrEven == "odd" ? 1 : 0;
            int[] filteredArr = numbers.Where(n => n % 2 == reminder).ToArray();
            string output = commandName == "first"
                ? "[" + string.Join(", ", filteredArr.Take(count).ToArray()) + "]"
                : "[" + string.Join(", ",filteredArr.Skip(filteredArr.Length - count).ToArray())+ "]";
            Console.WriteLine(output);
        }

        private static string MaxOrMin(int[] numbers, string commandName, string oddOrEven)
        {
            int reminder = oddOrEven == "odd" ? 1 : 0;
            int[] filteredArr = numbers.Where(n => n % 2 == reminder).ToArray();
            if (filteredArr.Length == 0)
            {
                return  "No matches";
            }
            int index = commandName == "max" ? Array.LastIndexOf(filteredArr, filteredArr.Max())
                : Array.LastIndexOf(filteredArr, filteredArr.Min());

            return index.ToString();
        }

        private static int[] Exchange(int[] numbers, int index)
        {
            int[] resultArr = numbers.Skip(index + 1).Concat(numbers.Take(index + 1)).ToArray();
            return resultArr;
        }
    }
} 

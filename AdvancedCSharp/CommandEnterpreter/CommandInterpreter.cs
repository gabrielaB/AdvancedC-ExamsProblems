using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandEnterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] elements = input.Split();
                string command = elements[0];
                try
                {
                    switch (command)
                    {
                        case "reverse":
                            Reverse(numbers, elements);
                            break;
                        case "sort":
                            Sort(numbers, elements);
                            break;
                        case "rollLeft":
                            RollLeft(numbers, elements);
                            break;
                        case "rollRight":
                            RollRight(numbers, elements);
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ",numbers) + "]");
        }

        public static void Reverse(List<string> numbers, string[] elements)
        {
            int start = int.Parse(elements[2]);
            int count = int.Parse(elements[4]);
            if (start == numbers.Count)
            {
                throw new ArgumentException();
            }
            numbers.Reverse(start, count);
        }

        public static void Sort(List<string> numbers, string[] elements)
        {
            int start = int.Parse(elements[2]);
            int count = int.Parse(elements[4]);
            if (start == numbers.Count)
            {
                throw new ArgumentException();
            }
            numbers.Sort(start, count, StringComparer.InvariantCulture);
        }

        public static void RollLeft(List<string> numbers, string[] elements)
        {
            int count = int.Parse(elements[1]) % numbers.Count;
            List<string> elementsToMove = numbers.Take(count).ToList();
            numbers.RemoveRange(0, count);
            numbers.AddRange(elementsToMove);
        }

        public static void RollRight(List<string> numbers, string[] elements)
        {
            int count = int.Parse(elements[1]) % numbers.Count;
            List<string> elementsToMove = numbers.Skip(numbers.Count - count).Take(count).ToList();
            numbers.RemoveRange(numbers.Count - count, count);
            numbers.InsertRange(0, elementsToMove);

        }

    }
}

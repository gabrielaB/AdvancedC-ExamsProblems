using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArraySlider
{
    class ArraySlider
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            string input = Console.ReadLine();
            BigInteger[] numbers = inputNumbers.Select(BigInteger.Parse).ToArray();
            int currentIndex = 0;
            while (input != "stop")
            {
                string[] elements = input.Split();
                int offset = int.Parse(elements[0]) % numbers.Length;
                string operation = elements[1];
                int operand = int.Parse(elements[2]);
                if(offset < 0)
                {
                    offset += numbers.Length;
                }

                currentIndex = (currentIndex + offset) % numbers.Length;
                switch (operation)
                {
                    case "*":
                        numbers[currentIndex] *= operand;
                        break;
                    case "/":
                        numbers[currentIndex] /= operand;
                        break;
                    case "+":
                        numbers[currentIndex] += operand;
                        break;
                    case "-":
                        numbers[currentIndex] -= operand;
                        break;
                    case "&":
                        numbers[currentIndex] &= operand;
                        break;
                    case "|":
                        numbers[currentIndex] |= operand;
                        break;
                    case "^":
                        numbers[currentIndex] ^= operand;
                        break;
                }
                if(numbers[currentIndex] < 0)
                {
                    numbers[currentIndex] = 0;
                }
                input = Console.ReadLine();

            }

            Console.WriteLine("[" + string.Join(", ",numbers)+ "]") ;
        }
    }
}

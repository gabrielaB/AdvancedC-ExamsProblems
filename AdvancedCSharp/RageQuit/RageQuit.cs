using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex("(\\D+)(\\d+)");
            MatchCollection matches = regex.Matches(input);
            StringBuilder output= new StringBuilder();

            foreach (Match match in matches)
            {
                string message = match.Groups[1].Value;
                int repeatCount = int.Parse(match.Groups[2].Value);
                output.Append(String.Concat(Enumerable.Repeat(message.ToUpper(), repeatCount)));
            }

            int countUniqueSymbols = output.ToString().Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}",countUniqueSymbols);
            Console.WriteLine(output.ToString());

            
        }
    }
}

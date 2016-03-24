using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShmoogleCounter
{
    class ShmoogleCounter
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();
            Regex regex = new Regex("(double|int)\\s+([a-z][A-Za-z]*)");
            while (input!= "//END_OF_CODE")
            {
                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string type = match.Groups[1].Value;
                        string name = match.Groups[2].Value;
                        if (type == "double")
                        {
                            doubles.Add(name);
                        }
                        else
                        {
                            ints.Add(name);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            doubles.Sort();
            ints.Sort();
            string doublesOutput = doubles.Count > 0 ? string.Join(", ", doubles) : "None";
            string intsOutput = ints.Count > 0 ? string.Join(", ", ints) : "None";
            Console.WriteLine("Doubles: " + doublesOutput);
            Console.WriteLine("Ints: " + intsOutput);
        }
    }
}

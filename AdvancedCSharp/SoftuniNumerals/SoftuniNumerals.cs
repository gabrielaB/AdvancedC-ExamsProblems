using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniNumerals
{
    class SoftuniNumerals
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string[] couples = new string[] { "aa", "aba", "bcc", "cc", "cdc" };
            string number = "";
            string output = "";
            decimal baseNumber = 0;
            int power = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                string currentLetter = inputString[i].ToString();
                output += currentLetter;
                if (output.Equals("aa"))
                {
                    number+="0";
                    output = "";
                }
                else if (output.Equals("aba"))
                {
                    number+="1";
                    output = "";
                }
                else if (output.Equals("bcc"))
                {
                    number+="2";
                    output = "";
                }
                else if (output.Equals("cc"))
                {
                    number+="3";
                    output = "";
                }
                else if (output.Equals("cdc"))
                {
                    number+="4";
                    output = "";
                }
                
            }

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentNum = int.Parse(number[i].ToString());
                baseNumber += currentNum * (decimal)(Math.Pow(5, power));
                power++;
            }

            Console.WriteLine(baseNumber);
        }
    }
}

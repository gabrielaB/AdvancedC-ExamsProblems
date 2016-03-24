using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTransformer
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder message = new StringBuilder();
            while (input != "burp")
            {

                message.Append(input);

                input = Console.ReadLine();
            }
            string wholeMessage = message.ToString();
            Regex regexWhiteSpace = new Regex("\\s+");
            wholeMessage = regexWhiteSpace.Replace(wholeMessage, " ");
            Regex extractRegex=new Regex("\\$[^$%&']+\\$|\\%[^$%&']+\\%|\\&[^$%&']+\\&|\'[^$%&']+\'");
            MatchCollection matches = extractRegex.Matches(wholeMessage);
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string currentMatch = match.ToString();
                string matchStartsWith = currentMatch[0].ToString();
                switch (matchStartsWith)
                {
                    case "$":
                        currentMatch = currentMatch.Replace("$", "");
                        TransformMessage(currentMatch, output,1);
                        break;
                    case "%":
                        currentMatch = currentMatch.Replace("%", "");
                        TransformMessage(currentMatch, output, 2);
                        break;
                    case "&":
                        currentMatch = currentMatch.Replace("&", "");
                        TransformMessage(currentMatch, output, 3);
                        break;
                    case "'":
                        currentMatch = currentMatch.Replace("'", "");
                        TransformMessage(currentMatch, output, 4);
                        break;
                }
            }
            Console.WriteLine(output.ToString());

        }

        private static void TransformMessage(string currentMatch, StringBuilder output,int specialCharValue)
        {
            for (int i = 0; i < currentMatch.Length; i++)
            {
                char currentChar = currentMatch[i];
                char newChar;
                if (i%2 == 0)
                {
                    newChar = (char) (currentChar + specialCharValue);
                }
                else
                {
                    newChar = (char) (currentChar - specialCharValue);
                }
                output.Append(newChar);
            }
            output.Append(" ");
        }
    }
}

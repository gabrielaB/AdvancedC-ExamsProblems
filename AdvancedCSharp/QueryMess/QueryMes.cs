using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryMess
{
    class QueryMes
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex("([^&\n\r?]+)=([^&\n\r]+)");
            Regex spaceRegex = new Regex("(\\+|%20)+");

            while (input != "END")
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    string key = match.Groups[1].Value;
                    string value = match.Groups[2].Value;
                    key = spaceRegex.Replace(key, " ");
                    value = spaceRegex.Replace(value, " ");
                    key = key.Trim();
                    value = value.Trim();
                    if (!keyValuePairs.ContainsKey(key))
                    {
                        keyValuePairs.Add(key, "");
                    }
                    keyValuePairs[key] += value + ", ";

                }

                foreach (var record in keyValuePairs)
                {
                    string outputValue = record.Value.Substring(0, record.Value.Length - 2);
                    Console.Write("{0}=[{1}]", record.Key, outputValue);
                }
                Console.WriteLine();


                input = Console.ReadLine();
            }
        }
    }
}

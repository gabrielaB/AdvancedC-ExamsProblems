using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SrabskoUnleashed
{
    class SrabskoUnleashed
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex("(\\D+)\\s@(\\D+)\\s(\\d+)\\s(\\d+)");
            Dictionary<string, Dictionary<string, int>> concertInfo = new Dictionary<string, Dictionary<string, int>>();

            while (input != "End")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string venue = match.Groups[2].Value;
                    int price = int.Parse(match.Groups[3].Value);
                    int ticketsCount = int.Parse(match.Groups[4].Value);

                    if (!concertInfo.ContainsKey(venue))
                    {
                        concertInfo.Add(venue, new Dictionary<string, int>());
                    }
                    if (!concertInfo[venue].ContainsKey(name))
                    {
                        concertInfo[venue].Add(name, 0);
                    }

                    concertInfo[venue][name] += ticketsCount * price;

                }
                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> record in concertInfo)
            {
                Console.WriteLine(record.Key);

                var sortedDictionary = record.Value.OrderByDescending(d => d.Value);
                foreach (KeyValuePair<string, int> revenue in sortedDictionary)
                {
                    Console.WriteLine("#  {0} -> {1}", revenue.Key, revenue.Value);
                }
            }
        }
    }
}

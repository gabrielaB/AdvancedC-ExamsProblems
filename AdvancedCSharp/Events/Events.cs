using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Events
{
    class Events
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Regex regex = new Regex("#([a-zA-Z]+):\\s*@([a-zA-Z]+)\\s*(\\d+:\\d+)");
            Dictionary<string, Dictionary<string, List<string>>> eventsInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string city = match.Groups[2].Value;
                    string time = match.Groups[3].Value;

                    if (!eventsInfo.ContainsKey(city))
                    {
                        eventsInfo.Add(city, new Dictionary<string, List<string>>());
                    }
                    if (!eventsInfo[city].ContainsKey(name))
                    {
                        eventsInfo[city].Add(name, new List<string>());
                    }
                    eventsInfo[city][name].Add(time);
                }
            }
            string[] townsInput = Console.ReadLine().Split(',');
            string currentCity = "";
            for (int i = 0; i < townsInput.Length; i++)
            {
                currentCity = townsInput[i];

            }

            var sortedDictionary = eventsInfo.OrderBy(k => k.Key);
            foreach (var cityInfo in sortedDictionary)
            {
                if (!currentCity.Contains(cityInfo.Key))
                {
                    continue;
                }

                Console.WriteLine("{0}:", cityInfo.Key);
                var sortedInnerDictionary = cityInfo.Value.OrderBy(v => v.Key);
                int counter = 1;
                foreach (var record in sortedInnerDictionary)
                {

                    var sortedRecordValue = record.Value.Select(p => p).OrderBy(r => r);
                   
                    Console.WriteLine("{0}. {1} -> {2}", counter, record.Key, string.Join(", ", sortedRecordValue));
                    counter++;

                }

            }
        }

    }
}


  

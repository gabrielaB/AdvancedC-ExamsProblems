using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlympicsAreComming
{
    class OlympicsAreComming
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex("\\s+");
            Dictionary<string, List<string>> olympicsInfo = new Dictionary<string, List<string>>();
            while (input != "report")
            {
                string[] elements = input.Split('|'); 
                string nameParts = elements[0].Trim();
                string countryParts = elements[1].Trim();
                string name = regex.Replace(nameParts, " ");
                string country = regex.Replace(countryParts, " ");

                if (!olympicsInfo.ContainsKey(country))
                {
                    olympicsInfo.Add(country, new List<string>());
                }
                olympicsInfo[country].Add(name);

                input = Console.ReadLine();
            }

            var sortedDictionary = olympicsInfo.OrderByDescending(r => r.Value.Count);
            foreach (var record in sortedDictionary)
            {
                var participants = record.Value.Select(x => x).Distinct().Count();
                Console.WriteLine("{0} ({1} participants): {2} wins", record.Key, participants, record.Value.Count);
            }


        }
    }
}

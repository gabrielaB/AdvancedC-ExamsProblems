using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,long>> population= new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] elements = input.Split('|');
                string city = elements[0];
                string country = elements[1];
                long populationCount = long.Parse(elements[2]);

                if (!population.ContainsKey(country))
                {
                    population.Add(country,new Dictionary<string, long>());
                }
                if (!population[country].ContainsKey(city))
                {
                    population[country].Add(city,0);
                }
                population[country][city] += populationCount;

                input = Console.ReadLine();
            }

            
            var sortedDictionary = population.OrderByDescending(p => p.Value.Sum(c => c.Value));
            foreach (var countryData in sortedDictionary)
            {
                string countryName = countryData.Key;
                Console.WriteLine("{0} (total population: {1})",countryName,countryData.Value.Sum(p=> p.Value));

                var sortedInnerDictionary = countryData.Value.OrderByDescending(p => p.Value);

                foreach (var cityData in sortedInnerDictionary)
                {
                    string cityName = cityData.Key;
                    long cityPopulation = cityData.Value;
                    Console.WriteLine("=>{0}: {1}",cityName,cityPopulation);

                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColletctResources
{
    class CollectResources
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int step = int.Parse(parameters[1]);
                for (int j = 0; j < input.Length; j++)
                {
                    
                    string elements = input[j];
                    string[] resourcesParts = elements.Split('_');
                    string resource = resourcesParts[0];
                    int value = int.Parse(resourcesParts[1]);
                    if(resource=="stone" || resource=="gold" || resource=="wood" || resource == "food")
                    {
                        sum += value;
                    }
                   
                    
                }
              
            }
        }
    }
}

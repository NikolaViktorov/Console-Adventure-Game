using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data.CustomNames
{
    public static class LevelNames
    {
        public static List<string> names = new List<string>()
        {
            "The dark forest",
            "The abandoned mansion"
        };
        private static List<int> usedNames = new List<int>();

        public static string GetRandomLevelName()
        {
            Random random = new Random();
            int randomNameIndex = random.Next(0, names.Count);
            if (usedNames.Contains(randomNameIndex) == false)
            {
                usedNames.Add(randomNameIndex);
            }
            else
            {
                int i = 0;
                while (usedNames.Contains(randomNameIndex))
                {
                    if (i == 25)
                    {
                        Console.WriteLine("DEBUG: Couldn't find available level name!");
                        break;
                    }
                    randomNameIndex = random.Next(0, names.Count);
                    i++;
                }
            }


            return names[randomNameIndex];
        }
    }
}

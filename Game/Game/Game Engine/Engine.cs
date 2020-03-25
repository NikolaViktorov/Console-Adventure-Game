using Game.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game_Engine
{
    public class Engine
    {
        public static List<Hero> heroes { get; set; }

        public Engine(/*picked hero*/)
        {
            Play();
        }
        public void Play()
        {
            Hero hero = PickHero();
            Console.WriteLine(hero);
        }

        private Hero PickHero()
        {
            List<string> names = new List<string>();
            bool picked = false;
            Console.WriteLine("Pick a hero from these down below:");
            foreach (var hero in heroes)
            {
                if (hero.Type.ToString() == "ItemHolder")
                {
                    continue;
                }
                Console.WriteLine(hero);
                names.Add(hero.Type.ToString());
            }
            Console.WriteLine("Type his name to select him!");
            string name = Console.ReadLine();
            while (picked == false)
            {
                if (!names.Contains(name))
                {
                    name = Console.ReadLine();
                }
                else
                {
                    picked = true;
                }
            }

            Hero pickedHero = heroes.FirstOrDefault(h => h.Type.ToString() == name);

            return pickedHero;
        }
    }
}

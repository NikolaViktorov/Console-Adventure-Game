using Game.Data.Models;
using Game.GameController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Displays
{
    public class ConsoleDisplay
    {
        public static List<Hero> heroes;

        public Hero PickHero()
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
                    Console.WriteLine("Please pick an existing hero!");
                    name = Console.ReadLine();
                }
                else
                {
                    picked = true;
                }
            }

            Hero pickedHero = heroes.FirstOrDefault(h => h.Type.ToString() == name);
            Console.WriteLine($"You picked {pickedHero}");

            return pickedHero;
        }

        internal string PickActionEnemy(Enemy enemy)
        {
            Console.WriteLine($"You met {enemy}!");
            Console.WriteLine("Pick what you want to do!");
            Console.WriteLine("1. Flee");
            Console.WriteLine("2. Attack");
            // bribe TODO
            string action = Console.ReadLine();
            while (action != "Attack" && action != "Flee")
            {
                Console.WriteLine("Pick real action!");
                action = Console.ReadLine();
            }

            return action;
        }

        internal string PickActionAdventurer(Adventurer adv)
        {
            Console.WriteLine($"You met {adv.Type}!");
            // diff adv types

            string action = "";

            return action;
        }


        internal void DisplayLevel(Level level)
        {
            Console.WriteLine(level);
        }

        internal void KilledEnemy(Enemy enemy)
        {
            Console.WriteLine($"You killed {enemy.Type}!");
            Console.WriteLine($"You just got {enemy.MoneyReward} gold!");
        }

        internal void EndScreen(Hero hero)
        {
            Console.WriteLine("You died!");
            Console.WriteLine("Your hero's statistics: ");
            Console.WriteLine(hero);
        }

        public int PickCreature()
        {
            Console.WriteLine("Where do you want to go? (pick a number between [1-5])");
            int numberPicked = int.Parse(Console.ReadLine());
            while (numberPicked < 1 || numberPicked > 5)
            {
                Console.WriteLine("You entered a wrong move! Please, enter a number between 1 and 5");
                numberPicked = int.Parse(Console.ReadLine());
            }
            return numberPicked;
        }
    }

   
}

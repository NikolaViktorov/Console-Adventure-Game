using Game.Data.Models;
using Game.GameController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine("Pick what you want to do! (Attack | Flee)");
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

        internal void CompletedGame(Hero hero)
        {
            Console.WriteLine("Congratulations you won the game!");
            ShowHeroStat(hero);
            // 1600 500
            Console.SetWindowSize(105, 20);

            string phaseA = System.Environment.NewLine + "                               *                               " + System.Environment.NewLine +
                "               *                             *       *'*'*       *              *       .----,         " + System.Environment.NewLine +
                "    *                  }               *              |||||        .----.              /#    '\\       " + System.Environment.NewLine +
                "          .--.        {                   )         @@.@.@.@@     /     \\  .          |      |        " + System.Environment.NewLine +
                "         /    \\                       }             |'='='=|    |'='='='|             |#    |'.       " + System.Environment.NewLine +
                "         |#   |                 *                  @@.@.@.@.@@    '._ _,/                '(^           " + System.Environment.NewLine +
                "         \\_ _.'        *              *    )       |'='='='='|     (^              *       )          " + System.Environment.NewLine +
                "          (^        *         .                    @@.@.@.@.@.@@     )          *           (          " + System.Environment.NewLine +
                "           )                        _    ___  _____  ____    ___  __  __  _                            " + System.Environment.NewLine +
                @"          (                 |   |  | |  |   | |   | |    |  |   \ \ \/ /  ||                          " + System.Environment.NewLine +
                @"           )                \   /  | |  |      | |  | || |  | - /  \  /   ||                          " + System.Environment.NewLine +
                @"                             \_/   |_|  |___|  |_|  |____|  |_._\  /_/    ()                          " + System.Environment.NewLine +
                @"                                                                                                      ";

            string phaseB = System.Environment.NewLine + "                               *                               " + System.Environment.NewLine +
                "               *                             *        *'*'*      *              *       .----,         " + System.Environment.NewLine +
                "    *                  }               *              |||||        .----.              /#    '\\       " + System.Environment.NewLine +
                "          .--.        {                   )         @@.@.@.@@     /     \\  .          |      |        " + System.Environment.NewLine +
                "         /    \\                       }             |'='='=|    |'='='='|             |#    |'.       " + System.Environment.NewLine +
                "         |#   |                 *                   @@.@.@.@.@@   '._ _,/                '^)           " + System.Environment.NewLine +
                "         \\_ _.'        *              *    )       |'='='='='|     ^)              *     (            " + System.Environment.NewLine +
                "          ^)        *         .                    @@.@.@.@.@.@@    (          *          )            " + System.Environment.NewLine +
                "          (                         _    ___  _____  ____    ___  __  __  _                            " + System.Environment.NewLine +
                @"          )                 |   |  | |  |   | |   | |    |  |   \ \ \/ /  ||                          " + System.Environment.NewLine +
                @"         (                  \   /  | |  |      | |  | || |  | - /  \  /   ||                          " + System.Environment.NewLine +
                @"                             \_/   |_|  |___|  |_|  |____|  |_._\  /_/    ()                          " + System.Environment.NewLine +
                @"                                                                                                      ";

            string phaseC = System.Environment.NewLine + "                               *                              " + System.Environment.NewLine +
                "               *                             *         *'*'*     *              *       .----,         " + System.Environment.NewLine +
                "    *                  }               *              |||||        .----.              /#    '\\       " + System.Environment.NewLine +
                "          .--.        {                   )         @@.@.@.@@     /     \\  .          |      |        " + System.Environment.NewLine +
                "         /    \\                       }             |'='='=|    |'='='='|              |#    |'.      " + System.Environment.NewLine +
                "         |#   |                 *                  @@.@.@.@.@@    '._ _,/                '(^           " + System.Environment.NewLine +
                "         \\_ _.'        *              *    )       |'='='='='|     (^              *       )          " + System.Environment.NewLine +
                "          (^        *         .                    @@.@.@.@.@.@@     )          *           (          " + System.Environment.NewLine +
                "           )                        _    ___  _____  ____    ___  __  __  _                            " + System.Environment.NewLine +
                @"          (                 |   |  | |  |   | |   | |    |  |   \ \ \/ /  ||                          " + System.Environment.NewLine +
                @"           )                \   /  | |  |      | |  | || |  | - /  \  /   ||                          " + System.Environment.NewLine +
                @"                             \_/   |_|  |___|  |_|  |____|  |_._\  /_/    ()                          " + System.Environment.NewLine +
                @"                                                                                                      ";
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(phaseA);
                Thread.Sleep(300);
                Console.Clear();

                Console.WriteLine(phaseB);
                Thread.Sleep(300);
                Console.Clear();

                Console.WriteLine(phaseC);
                Thread.Sleep(300);
                Console.Clear();

                Console.WriteLine(phaseB);
                Thread.Sleep(300);
                Console.Clear();
            }


        }

        internal void NextLevel(Level level)
        {
            Console.WriteLine($"You finished the {level.Name}");
        }

        internal bool PickActionAdventurer(Adventurer adv)
        {
            Console.WriteLine($"You met {adv.Type}!");
            bool deal = false;
            string answer = "";

            switch (adv.Type)
            {
                case AdventurerType.Elf:
                    Console.WriteLine("The elf is a mythic creature, which has the power to double your power for the price of 100 Gold! Will you accept this great deal?");
                    answer = Console.ReadLine();
                    break;
                case AdventurerType.Unicorn:
                    Console.WriteLine("The unicorn is the friendliest creature you can find in this game! It will charge you nothing and will give you 40 HP. Will you accept this great deal?");
                    answer = Console.ReadLine();
                    break;
                case AdventurerType.Merchant:
                    Console.WriteLine("The merchant is a very clever and insidious person. He will trade you some items for a price. Here are the items you can choose from: "); // TODO ADD ITEMS
                    answer = Console.ReadLine();
                    break;
                case AdventurerType.Doctor:
                    Console.WriteLine("The doctor is ready to make you stronger by healing you by 50HP and giving you 20 power but for the cost of 5 % of your total gold. Will you accept this great deal?");
                    answer = Console.ReadLine();
                    break;
                case AdventurerType.Ghost:
                    Console.WriteLine(); // TODO
                    answer = Console.ReadLine();
                    break;
                case AdventurerType.WiseMan:
                    Console.WriteLine(); // TODO
                    answer = Console.ReadLine(); 
                    break;
                case AdventurerType.Gnome:
                    Console.WriteLine(); // TODO
                    answer = Console.ReadLine();
                    break;
                default:
                    break;
            }

            deal = CheckAnswer(answer);

            return deal;
        }
        
        private bool CheckAnswer(string answer)
        {
            if (answer == "Deal")
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        internal void ShowHeroStat(Hero hero)
        {
            Console.WriteLine("Your hero stats are: " + hero);
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

        public int PickCreature(bool failed)
        {
            int numberPicked = 0;
            if (failed)
            {
                Console.WriteLine("Please pick a number that exists in the current level!");
                numberPicked = int.Parse(Console.ReadLine());
                return numberPicked;
            }

            Console.WriteLine("Where do you want to go? (pick a number)");
                numberPicked = int.Parse(Console.ReadLine());
            while (numberPicked < 1 || numberPicked > 5)
            {
                Console.WriteLine("You entered a wrong move! Please, enter a number between 1 and 5");
                numberPicked = int.Parse(Console.ReadLine());
            }
            
            return numberPicked;
        }
    }

   
}

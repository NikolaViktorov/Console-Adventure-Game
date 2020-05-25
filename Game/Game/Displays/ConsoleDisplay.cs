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
            string action = Console.ReadLine();
            while (action != "Attack" && action != "Flee" && action != Controller.wise)
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
            Console.WriteLine($"You finished the {level.Name}!");
        }

        internal string PickActionAdventurer(Adventurer adv, params Item[] items)
        {
            Console.WriteLine($"You met {adv.Type}!");
            string answer = "";
            do
            {
                switch (adv.Type)
                {
                    case AdventurerType.Elf:
                        Console.WriteLine("The elf is a mythic creature, which has the power to double your power for the price of 100 Gold! Will you accept this great deal? (Yes|No)");
                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.Unicorn:
                        Console.WriteLine("The unicorn is the friendliest creature you can find in this game! It will charge you nothing and will give you 40 HP. Will you accept this great deal? (Yes|No)");
                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.Merchant:
                        Console.WriteLine("The merchant is a very clever and insidious person. He will trade you some items for a price. Here are the items you can choose from: (Write the number of the item)");

                        for (int i = 0; i < items.Length; i++)
                        {
                            Console.WriteLine($"    {i + 1}. {items[i]}");
                        }
                        Console.WriteLine($"    {items.Length + 1}. Exit");

                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.Doctor:
                        Console.WriteLine("The doctor is ready to make you stronger by healing you by 50HP and giving you 20 power but for the cost of 20 % of your total gold. Will you accept this great deal? (Yes|No)");
                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.Ghost:
                        Console.WriteLine("The ghost is a very tricky creature. If you have enough gold, you can give it to him and he will haunt you, doubling your power! He needs only 125 gold. Will you accept this great deal? (Yes|No)");
                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.WiseMan:
                        Console.WriteLine("This old and wise man has the secret to very strong magic spell. This spell can be used only 1 time and it will kill an enemy in 1 shot. The key to this magic is 200 gold. Will you accept this great deal? (Yes|No)"); // 

                        answer = Console.ReadLine();
                        break;
                    case AdventurerType.Gnome:
                        Console.WriteLine("The gnome is a very cunning. He can tell you a secret code to a mystery room, if you wish to accept the deal you will get the code which you can use in the dungeon to go to the mystery room. In the secret room there may be good things waiting for you like gold or items, but if you get unlucky you will get a curse. Your choice is wheter to believe him or not. It will cost you 150 gold. Will you accept this great deal? (Yes|No)");
                        answer = Console.ReadLine();
                        break;
                    default:
                        break;
                }
            } while (answer != "Yes" && answer != "No" && int.Parse(answer) < 0 && int.Parse(answer) > items.Length + 1);

            return answer;
        } 
        
        public bool CheckAnswer(string answer)
        {
            if (answer == "Yes")
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

        private void DisplayItemMerchant()
        {

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
            try
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
            catch (FormatException ex)
            {
                PickCreature(true);
                return -1;
            }
            
        }
    }

   
}

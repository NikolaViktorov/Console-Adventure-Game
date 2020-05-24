using Game.Data;
using Game.Data.CustomNames;
using Game.Data.Models;
using Game.GameController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game_Engine
{
    public class Engine
    {
        public Hero Hero { get; set; }

        public Enemy Enemy { get; set; }
        public List<Level> Levels { get; set; }

        DatabaseConnector db = new DatabaseConnector();

        private Random rnd = new Random();

        private int currLevelIndex;
            
        internal bool usedMagic = false;

        public Engine()
        {
            Levels = new List<Level>();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Level MakeLevel()
        {
            Level level = new Level();
            level.Enemies = PickFourRandomEnemies();
            level.Adventurers = PickRandomAdventurers(1); // TODO add random maybe to enemies (3-5) 
                                                          // so there can be 2 - 1 - 0 adventurers
            level.Name = LevelNames.GetRandomLevelName();
            return level;
        }

        private List<Adventurer> PickRandomAdventurers(int count)
        {
            using var context = new GameContext();
            List<Adventurer> allAdventureres = context.Adventurers.ToList();
            List<Adventurer> RandomAdventureres = new List<Adventurer>();
            int endIndex = allAdventureres.Count;

            int randomIndex = random.Next(1, endIndex);
            for (int i = 0; i < count; i++)
            {
                RandomAdventureres.Add(allAdventureres[randomIndex]); // randomIndex gnome = 0 wise = 1
                randomIndex = random.Next(1, endIndex);
            }

            return RandomAdventureres;
        }

        internal Enemy PickEnemy(int action)
        {
            Enemy enemy = db.GetEnemyWithIndexInLevel(currLevelIndex, action);
            this.Enemy = enemy;
            return enemy;
        }

        internal Adventurer PickAdventurer()
        {
            Adventurer adventurer = db.GetAdventurerInLevel(currLevelIndex);
            return adventurer;
        }

        internal string PlayActionEnemy(string action)
        {
            switch (action)
            {
                case "Attack":
                    return Hero.AttackEnemy(Enemy);
                case "Flee":
                    return ";";
                default:
                    if (!usedMagic)
                    {
                        usedMagic = true;
                        return Enemy.Die();
                    }
                    return ";";
            }
        }

        internal void PlayActionAdventurer(Adventurer adv, bool deal)
        {
            if (deal)
            {
                switch (adv.Type)
                {
                    case AdventurerType.Elf:
                        if (Hero.Money < 100)
                        {
                            Console.WriteLine("You do not have enough money, maybe try killing some enemies firsst!");
                        }
                        else
                        {
                            Hero.Money -= 100;
                            Hero.Power *= 2;
                        }
                        break;
                    case AdventurerType.Unicorn:
                        Hero.Health += 40;
                        break;
                    case AdventurerType.Merchant:
                        break;
                    case AdventurerType.Doctor:
                        int neededMoney = Hero.Money * 20 / 100;
                        Hero.Money -= neededMoney;
                        Hero.Health += 50;
                        Hero.Power += 20;
                        break;
                    case AdventurerType.Ghost:
                        break;
                    case AdventurerType.WiseMan:
                        if (Hero.Money < 200)
                        {
                            Console.WriteLine("You do not have enough money, maybe try killing some enemies firsst!");
                        }
                        else
                        {
                            Hero.Money -= 200;
                            Console.WriteLine($"The magic spell is: {Controller.wise}");
                        }
                            break;
                    case AdventurerType.Gnome:
                        if (Hero.Money < 150)
                        {
                            Console.WriteLine("You do not have enough money, maybe try killing some enemies firsst!");
                        }
                        else
                        {
                            Hero.Money -= 150;
                            bool goodOrBad = rnd.Next(101) < 75; // 75% good, 25% bad ADJUST
                            if (goodOrBad)
                            {
                                bool hpOrPower = rnd.Next(3) == 1; // true = hp / false = power
                                Console.WriteLine("You got lucky! Your stats got boosted!");
                                if (hpOrPower)
                                {
                                    Hero.Health += 70;
                                }
                                else
                                {
                                    Hero.Power += 35;
                                }
                            }
                            else
                            {
                                int cursePower = rnd.Next(25);
                                Console.WriteLine($"Oh, no! You got cursed and lost {cursePower} power!");
                                if (Hero.Power <= cursePower)
                                {
                                    Hero.Power = 1;
                                }
                                else
                                {
                                    Hero.Power -= cursePower;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        internal void EnemyKilled(int enemyIndex, int levelIndex)
        {
            enemyIndex -= 1;
            this.Hero.Money += this.Enemy.MoneyReward;
            Levels[levelIndex].Enemies.RemoveAt(enemyIndex);
            db.DeleteEnemy(this.Enemy);
        }

        internal Level LoadLevel(int levelIndex)
        {
            Level level = Levels[levelIndex];
            currLevelIndex = levelIndex + 2; // if its level 0 in database its level 2 because lvl 1 is itemholder

            return level;
        }

        internal void AddLevelToDB(Level level)
        {
            using var db = new GameContext();

            db.Levels.Add(new Level() { Name = level.Name });
            db.SaveChanges();
            int levelId = db.Levels.ToList().Last().LevelId;


            var enemies = new List<Enemy>();
            var adventurers = new List<Adventurer>();
            foreach (var enemy in level.Enemies)
            {
                enemies.Add(new Enemy()
                {
                    Type = enemy.Type,
                    Health = enemy.Health,
                    Power = enemy.Power,
                    MoneyReward = enemy.MoneyReward,
                    LevelId = levelId
                });
            }
            foreach (var adventurer in level.Adventurers)
            {
                adventurers.Add(new Adventurer()
                {
                    Type = adventurer.Type,
                    LevelId = levelId
                });
            }
            db.Enemies.AddRange(enemies);
            db.Adventurers.AddRange(adventurers);
            db.SaveChanges();
        }

        private List<Enemy> PickFourRandomEnemies()
        {
            using var context = new GameContext();
            List<Enemy> allEnemies = context.Enemies.ToList();
            List<Enemy> fourRandomEnemies = new List<Enemy>();
            int endIndex = allEnemies.Count;

            
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = random.Next(1, endIndex);
                Enemy enemy = allEnemies[randomIndex];
                //enemy.Items.Add(new Item()
                //{
                //    Name = "l",
                //    Type = ItemType.Health,
                //    UpgradeValue = 100
                //});
                fourRandomEnemies.Add(enemy);
            }

            return fourRandomEnemies;
        }

        
    }
}

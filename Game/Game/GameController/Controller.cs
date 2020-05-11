using Game.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Displays;
using Game.Data.Models;
using Game.Data.CustomNames;
using Game.Data;

namespace Game.GameController
{
    public class Controller
    {
        public static List<Hero> heroes { get; set; }

        public Engine Engine { get; set; }

        public ConsoleDisplay Display { get; set; }

        DatabaseConnector db = new DatabaseConnector();

        public Controller()
        {
            Engine = new Engine();
            Display = new ConsoleDisplay();
            startGame();
        }

        void startGame()
        {
            Engine.Hero = Display.PickHero(); // избира герой

            #region 
            for (int i = 0; i < LevelNames.names.Count; i++)
            {
                Level newLevel = Engine.MakeLevel();
                Engine.Levels.Add(newLevel);
                Engine.AddLevelToDB(newLevel);
            }
            Level level = Engine.LoadLevel(0);
            #endregion  
            // Levels

            #region
            while (true) // TODO ADD NEXT LEVEL
            {
                Display.DisplayLevel(level);

                int creatureIndex = Display.PickCreature(false);
                while (creatureIndex > level.Enemies.Count + level.Adventurers.Count || creatureIndex < 0 )
                {
                    creatureIndex = Display.PickCreature(true);
                }
                Enemy enemy = new Enemy();
                Adventurer adventurer = new Adventurer();
                bool enemyOrAdventurer = false; // FALSE = Eneme, TRUE = Adventurer
                if (creatureIndex <= level.Enemies.Count)
                {
                    enemy = Engine.PickEnemy(creatureIndex);
                    enemyOrAdventurer = false;
                }
                else
                {
                    adventurer = Engine.PickAdventurer();
                    enemyOrAdventurer = true;
                }
                #endregion
                // Creature
                #region
                
                if (enemyOrAdventurer) // adv == true | enemy = false
                {
                    bool deal = Display.PickActionAdventurer(adventurer);
                    Engine.PlayActionAdventurer(adventurer, deal);
                }
                else
                {
                    string action = "";
                    Display.ShowHeroStat(Engine.Hero);
                    action = Display.PickActionEnemy(enemy);
                    string result = Engine.PlayActionEnemy(action);
                    while (result == "Fought" && action == "Attack")
                    {
                        Display.ShowHeroStat(Engine.Hero);
                        action = Display.PickActionEnemy(enemy);
                        result = Engine.PlayActionEnemy(action);
                    }
                    if (action == "Flee")
                    {
                        level.Enemies[creatureIndex - 1] = Engine.Enemy;
                        db.UpdateEnemy(Engine.Enemy);
                        continue;
                    }
                    // while result = fought -> else check enemy died or hero died
                    if (result == "Enemy died")
                    {
                        Display.KilledEnemy(Engine.Enemy);
                        Engine.EnemyKilled(creatureIndex);
                        continue;
                    }
                    else if (result == "Hero died")
                    {
                        Display.EndScreen(Engine.Hero);
                    }

                }
                    #endregion
            }

        }
    }
}

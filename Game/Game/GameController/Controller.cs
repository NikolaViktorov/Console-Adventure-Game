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
            Display.DisplayLevel(level);
            #endregion  
            // Levels

            #region
            int creatureIndex = Display.PickCreature();
            Enemy enemy = new Enemy();
            Adventurer adventurer = new Adventurer();
            bool enemyOrAdventurer = false; // FALSE = Eneme, TRUE = Adventurer
            if (creatureIndex <= 4)
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
            string action = "";
            if (enemyOrAdventurer) // adv == true | enemy = false
            {
                action = Display.PickActionAdventurer(adventurer);
                //Engine.PlayActionAdventurer(action);
            }
            else
            {
                action = Display.PickActionEnemy(enemy);
                string result = Engine.PlayActionEnemy(action);
                switch (result)
                {
                    case "Enemy died":
                        Display.KilledEnemy(Engine.Enemy);
                        Engine.EnemyKilled(creatureIndex);
                        break;
                    case "Hero died":
                        Display.EndScreen(Engine.Hero);
                        break;
                    case "Fought":
                        break;
                }
            }
            #endregion
        }
    }
}

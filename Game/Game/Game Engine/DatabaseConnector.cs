using Game.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Data;

namespace Game.Game_Engine
{
    public class DatabaseConnector
    {
        public object Adventurer { get; private set; }

        public Enemy GetEnemyWithIndexInLevel(int currLevelIndex, int enemyIndex)
        {
            enemyIndex -= 1;
            using var db = new GameContext();
            Enemy enemy = db.Enemies
                .Where(e => e.LevelId == currLevelIndex)
                .OrderBy(e => e.EnemyId)
                .Skip(enemyIndex)
                .FirstOrDefault();

            return enemy;
        }

        public Adventurer GetAdventurerInLevel(int currLevelIndex)
        {
            using var db = new GameContext();
            Adventurer adventurer = db.Adventurers
                    .Where(a => a.LevelId == currLevelIndex)
                    .FirstOrDefault();
            return adventurer;
        }
    }
}

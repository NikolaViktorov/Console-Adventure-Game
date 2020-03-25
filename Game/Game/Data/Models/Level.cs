using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data.Models
{
    public class Level
    {
        public Level()
        {
            this.Enemies = new HashSet<Enemy>();
            this.Adventurers = new HashSet<Adventurer>();
        }
        public int LevelId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Enemy> Enemies { get; set; }

        public ICollection<Adventurer> Adventurers { get; set; } 
    }
}

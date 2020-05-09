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
            this.Enemies = new List<Enemy>();
            this.Adventurers = new HashSet<Adventurer>();
        }
        public int LevelId { get; set; }

        public string Name { get; set; }
        
        public List<Enemy> Enemies { get; set; }

        public ICollection<Adventurer> Adventurers { get; set; }

        public override string ToString()
        {
            int i = 1;
            string result = Name + Environment.NewLine;
            foreach (var enemy in Enemies)
            {
                result += "   " + enemy + $" --> {i++}" + Environment.NewLine;
            }
            foreach (var adv in Adventurers)
            {
                result += "   " + adv + $" --> {i++}" + Environment.NewLine;
            }
            return result;
        }
    }
}

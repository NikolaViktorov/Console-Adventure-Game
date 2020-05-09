using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UpgradeValue { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int EnemyId { get; set; }

        public Enemy Enemy { get; set; }

        [Required]
        public ItemType Type { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Type} | {UpgradeValue}";
        }
    }
}

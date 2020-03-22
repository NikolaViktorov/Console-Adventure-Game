using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data.Models
{
    public class Enemy
    {
        public Enemy()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int EnemyId { get; set; }

        [Required]
        public int Health { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int MoneyReward { get; set; }

        public ICollection<Item> Items { get; set; }

        [Required]
        public EnemyType Type { get; set; }
    }
}

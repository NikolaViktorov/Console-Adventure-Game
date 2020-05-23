using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Game.Data.Models
{
    public class Hero
    {
        public Hero()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int HeroId { get; set; }

        [Required]
        public int Health { get; set; }

        [Required]
        public int Power { get; set; }

        public int Experience { get; set; }

        [Required]
        public int Money { get; set; }

        [Required]
        public HeroType Type { get; set; }

        public ICollection<Item> Items { get; set; }

        public string AttackEnemy(Enemy enemy)
        {
            //this.Power = 10000;  hack
            //this.Health = 10000; hack
            if (enemy.Health - this.Power <= 0)
            {
                enemy.Health = 0;
                return "Enemy died";
            }
            if (this.Health - enemy.Power <= 0)
            {
                this.Health = 0;
                return "Hero died";
            }
            enemy.Health -= this.Power;
            this.Health -= enemy.Power;
            return "Fought";
        }

        public override string ToString()
        {
            string result = $"{this.Type} with {Health} HP, {Power} DMG and {Money} Gold!";
            return result;
        }
    }
}

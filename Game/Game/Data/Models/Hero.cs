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

        public override string ToString()
        {
            string result = $"{this.Type} with {Health} HP, {Power} DMG and {Money} Gold!";
            return result;
        }
    }
}

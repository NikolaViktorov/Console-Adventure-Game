using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DataProcessor.ImportDTO
{
    public class ItemDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int UpgradeValue { get; set; }

        [Required]
        public int Price { get; set; }

        public int HeroId { get; set; }

        public int EnemyId { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

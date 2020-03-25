using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data.Models
{
    public class Adventurer
    {
        public int AdventurerId { get; set; }

        [Required]
        public AdventurerType Type { get; set; }

        public Level Level { get; set; }

        public int LevelId { get; set; }
    }
}

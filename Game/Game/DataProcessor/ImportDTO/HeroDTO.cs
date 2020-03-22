using Game.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DataProcessor.ImportDTO
{
    public class HeroDTO
    {
            [Required]
            public int Health { get; set; }

            [Required]
            public int Power { get; set; }

            public int Experience { get; set; }

            [Required]
            public int Money { get; set; }

            public string Type { get; set; }
    }
}

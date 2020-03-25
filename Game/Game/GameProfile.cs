using AutoMapper;
using Game.Data.Models;
using Game.DataProcessor.ImportDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            this.CreateMap<LevelDTO, Level>();
            this.CreateMap<HeroDTO, Hero>();
            this.CreateMap<EnemyDTO, Enemy>();
            this.CreateMap<ItemDTO, Item>();
            this.CreateMap<AdventurerDTO, Adventurer>();
        }
    }
}

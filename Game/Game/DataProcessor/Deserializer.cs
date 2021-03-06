﻿namespace Game.DataProcessor
{
    using AutoMapper;
    using Game.Data;
    using Game.Data.Models;
    using Game.DataProcessor.ImportDTO;
    using Game.Displays;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportHero
            = "Successfully imported hero with health {0}, power {1}, experience {2}, money {3} and type {4}!";
        private const string SuccessfulImportEnemy
            = "Successfully imported enemy with health {0}, power {1}, money reward {2} and type {3}!";
        private const string SuccessfulImportItem
            = "Successfully imported item with name {0}, upgrade value {1} and type {2}!";
        private const string SuccessfulImportLevel
           = "Successfully imported level with name {0}!";
        private const string SuccessfulImportAdventurer
          = "Successfully imported adventurer with type {0}!";

        public static string ImportHeroes(GameContext context, string jsonString)
        {
            var heroDtos = JsonConvert.DeserializeObject<HeroDTO[]>(jsonString);

            var heroes = new List<Hero>();
            var sb = new StringBuilder();

            foreach (var heroDto in heroDtos)
            {
                var isValidDto = IsValid(heroDto);
                bool isValidEnum = Enum.TryParse<HeroType>(heroDto.Type, out HeroType type);

                if (!isValidDto || !isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hero = Mapper.Map<Hero>(heroDto);

                heroes.Add(hero);

                sb.AppendLine(string.Format(SuccessfulImportHero, hero.Health, hero.Power, hero.Experience, hero.Money, hero.Type));
            }

            ConsoleDisplay.heroes = heroes;
            context.Heros.AddRange(heroes);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportLevels(GameContext context, string jsonString)
        {
            var levelDtos = JsonConvert.DeserializeObject<LevelDTO[]>(jsonString);

            var levels = new List<Level>();
            var sb = new StringBuilder();

            foreach (var levelDto in levelDtos)
            {
                var isValidDto = IsValid(levelDto);

                if (!isValidDto)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var level = Mapper.Map<Level>(levelDto);

                levels.Add(level);

                sb.AppendLine(string.Format(SuccessfulImportLevel, level.Name));
            }

            context.Levels.AddRange(levels);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }
        public static string ImportAdventurers(GameContext context, string jsonString)
        {
            var adventurerDtos = JsonConvert.DeserializeObject<AdventurerDTO[]>(jsonString);

            var adventurers = new List<Adventurer>();
            var sb = new StringBuilder();

            foreach (var adventurerDto in adventurerDtos)
            {
                var isValidDto = IsValid(adventurerDto);

                if (!isValidDto)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var adventurer = Mapper.Map<Adventurer>(adventurerDto);

                adventurers.Add(adventurer);

                sb.AppendLine(string.Format(SuccessfulImportAdventurer, adventurer.Type));
            }

            context.Adventurers.AddRange(adventurers);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportEnemies(GameContext context, string jsonString)
        {
            var enemyDtos = JsonConvert.DeserializeObject<EnemyDTO[]>(jsonString);

            var enemies = new List<Enemy>();
            var sb = new StringBuilder();

            foreach (var enemyDto in enemyDtos)
            {
                var isValidDto = IsValid(enemyDto);
                bool isValidEnum = Enum.TryParse<EnemyType>(enemyDto.Type, out EnemyType type);

                if (!isValidDto || !isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var enemy = Mapper.Map<Enemy>(enemyDto);

                enemies.Add(enemy);

                sb.AppendLine(string.Format(SuccessfulImportEnemy, enemy.Health, enemy.Power, enemy.MoneyReward, enemy.Type));
            }

            context.Enemies.AddRange(enemies);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportItems(GameContext context, string jsonString)
        {
            var itemDtos = JsonConvert.DeserializeObject<ItemDTO[]>(jsonString);

            var items = new List<Item>();
            var sb = new StringBuilder();

            foreach (var itemDto in itemDtos)
            {
                var isValidDto = IsValid(itemDto);
                bool isValidEnum = Enum.TryParse<ItemType>(itemDto.Type, out ItemType type);

                if (!isValidDto || !isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var item = Mapper.Map<Item>(itemDto);

                items.Add(item);

                sb.AppendLine(string.Format(SuccessfulImportItem, item.Name, item.UpgradeValue, item.Type));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

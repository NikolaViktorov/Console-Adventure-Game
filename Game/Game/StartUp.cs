using AutoMapper;
using Game.Data;
using Game.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new GameContext();
           
            Mapper.Initialize(config => config.AddProfile<GameProfile>());

            ResetDatabase(context, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
        }

        private static void ResetDatabase(GameContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }         
        }

        private static void ImportEntities(GameContext context, string baseDir, string exportDir)
        {
            var heroes =
                DataProcessor.Deserializer.ImportHeroes(context,
                    File.ReadAllText(baseDir + "heroes.json"));
            PrintEntity(heroes);

            var enemies =
               DataProcessor.Deserializer.ImportEnemies(context,
                   File.ReadAllText(baseDir + "enemies.json"));
            PrintEntity(enemies);

            var items =
              DataProcessor.Deserializer.ImportItems(context,
                  File.ReadAllText(baseDir + "items.json"));
            PrintEntity(items);
        }

        private static void PrintEntity(string entityOutput)
        {
            Console.WriteLine(entityOutput);

        }

        private static string GetProjectDirectory()
        {
            var relativePath = Path.GetFullPath(@"..\..\");

            return relativePath;
        }
    }
}

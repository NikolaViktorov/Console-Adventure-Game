using Game.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    public class GameContext : DbContext
    {
        public GameContext() { }

        public GameContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Hero> Heros { get; set; }

        public DbSet<Enemy> Enemies { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //modelBuilder.Entity<Hero>(entity =>
            //{
            //    entity.HasKey(h => h.HeroId);

            //    entity.Property(p => p.Health)
            //        .IsRequired(true);

            //    entity.Property(p => p.Money)
            //        .IsRequired(true);

            //    entity.Property(p => p.Power)
            //        .IsRequired(true);

            //    entity.Property(p => p.Type)
            //        .IsRequired(true);
            //});

            //modelBuilder.Entity<Enemy>(entity =>
            //{
            //    entity.HasKey(e => e.EnemyId);

            //    entity.Property(e => e.Health)
            //        .IsRequired();

            //    entity.Property(e => e.Power)
            //        .IsRequired();

            //    entity.Property(e => e.MoneyReward)
            //        .IsRequired();
            //});

            //modelBuilder.Entity<Item>(entity =>
            //{
            //    entity.HasKey(e => e.ItemId);

            //    entity.Property(e => e.Name)
            //        .IsRequired(true)
            //        .HasMaxLength(50)
            //        .IsUnicode(true);

            //    entity.Property(e => e.UpgradeValue)
            //        .IsRequired(true);
                
            //    entity.Property(e => e.Type)
            //        .IsRequired(true);

            //    entity.HasOne(i => i.Hero)
            //        .WithMany(h => h.Items)
            //        .HasForeignKey(i => i.HeroId);

            //    entity.HasOne(i => i.Enemy)
            //        .WithMany(e => e.Items)
            //        .HasForeignKey(i => i.EnemyId);
            //});
        }
    }
}

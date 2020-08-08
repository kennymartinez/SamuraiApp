﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samurai.Domain;

namespace Samurai.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Domain.Samurai> Samurais { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information)
                    .AddConsole();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer(
                    "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }
    }
}
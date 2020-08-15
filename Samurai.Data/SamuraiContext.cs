using Microsoft.EntityFrameworkCore;
using Samurai.Domain;

namespace Samurai.Data
{
    public class SamuraiContext : DbContext
    {
        public SamuraiContext()
        { }

        public SamuraiContext(DbContextOptions options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Samurai.Domain.Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=localhost;Database=SamuraiTestData;User Id=sa;Password=.Kenny20;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
        }
    }
}

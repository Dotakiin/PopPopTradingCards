using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PopPopTradingCardsLib.Models
{
    public class PopPopTradingCardsDbContext : DbContext
    {
        public PopPopTradingCardsDbContext()
        {

        }

        public PopPopTradingCardsDbContext(DbContextOptions<PopPopTradingCardsDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MagicCard> MagicCards { get; set; }
        public virtual DbSet<BaseballCard> BaseballCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.MagicCards);

                entity.HasMany(e => e.BaseballCards);
            });

            modelBuilder.Entity<MagicCard>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(e => e.MagicCards);
            });

            modelBuilder.Entity<BaseballCard>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(e => e.BaseballCards);
            });
        }
    }
}

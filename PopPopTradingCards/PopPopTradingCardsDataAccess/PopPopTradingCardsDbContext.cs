using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PopPopTradingCardsDataAccess.Entities;

namespace PopPopTradingCardsDataAccess
{
    public class PopPopTradingCardsDbContext : DbContext
    {
        public PopPopTradingCardsDbContext()
        {

        }

        public PopPopTradingCardsDbContext(DbContextOptions<PopPopTradingCardsDbContext> options) : base(options)
        {

        }
        //These tables must be named the same as the objects being stored. Cost of this knowledge: 1 hour of despair.
        public virtual DbSet<MagicCard> MagicCard { get; set; }
        public virtual DbSet<BaseballCard> BaseballCard { get; set; }
        public virtual DbSet<User> User { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.MagicCards);

                entity.HasMany(e => e.BaseballCards);
                entity.HasData(new User[]
                {
                    new User()
                    {
                        Id = -1,
                        Username = "CardList",
                        Password = "CardList"
                    },
                    new User()
                    {
                        Id = 1,
                        Username = "Magic",
                        Password = "Magic"
                    },
                    new User()
                    {
                        Id = 2,
                        Username = "Baseball",
                        Password = "Baseball"
                    },
                    new User()
                    {
                        Id = 3,
                        Username = "Both",
                        Password = "Both"
                    },
                    new User()
                    {
                        Id = 4,
                        Username = "Cardless",
                        Password = "Cardless"
                    }
                });
            });

            modelBuilder.Entity<MagicCard>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(e => e.MagicCards);
                entity.HasData(new MagicCard[]
                    {
                        new MagicCard()
                        {
                            Id = 4,
                            Name = "Ob Nixilis, the Fallen",
                            Color = "Black",
                            CMC = 5,
                            Type = "Legendary Creature - Demon",
                            Rarity = "Ultra Rare",
                            Booster = "Zendikar",
                            Location = "",
                            UserId = -1,
                            Image = "/Images/Ob_Nixilis_the_Fallen.jpg"
                        },
                        new MagicCard()
                        {
                            Id = 5,
                            Name = "Ob Nixilis, the Fallen",
                            Color = "Black",
                            CMC = 5,
                            Type = "Legendary Creature - Demon",
                            Rarity = "Ultra Rare",
                            Booster = "Zendikar",
                            Location = "",
                            UserId = 1,
                            Image = "/Images/Ob_Nixilis_the_Fallen.jpg"
                        },
                        new MagicCard()
                        {
                             Id = 1,
                             Name = "Vampire Nighthawk",
                             Color = "Black",
                             CMC = 3,
                             Type = "Creature - Vampire Shaman",
                             Rarity = "Uncommon",
                             Booster = "Zendikar",
                             Location = "Basement, red binder",
                             UserId = 1,
                             Image = "/Images/Vampire_Knighthawk_Zendikar.jfif"
                        },
                        new MagicCard()
                        {
                             Id = 2,
                             Name = "Vampire Nighthawk",
                             Color = "Black",
                             CMC = 3,
                             Type = "Creature - Vampire Shaman",
                             Rarity = "Uncommon",
                             Booster = "Zendikar",
                             Location = "",
                             UserId = -1,
                             Image = "/Images/Vampire_Knighthawk_Zendikar.jfif"
                        },
                        new MagicCard()
                        {
                             Id = 3,
                             Name = "Vampire Nighthawk",
                             Color = "Black",
                             CMC = 3,
                             Type = "Creature - Vampire Shaman",
                             Rarity = "Uncommon",
                             Booster = "Zendikar",
                             Location = "Basement, red binder",
                             UserId = 3,
                             Image = "/Images/Vampire_Knighthawk_Zendikar.jfif"
                        }
                    });
            });

            modelBuilder.Entity<BaseballCard>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(e => e.BaseballCards);
                entity.HasData(new BaseballCard[]
                {
                    new BaseballCard()
                    {
                         Id=1,
                         PlayerName = "Micky Mantle",
                         Location = "Red box in Attic",
                         Team = "New York Yankees",
                         Year = 1952,
                         UserId = -1,
                         Image = "/Images/Mickey_Mantle1952.jpg"
                    },
                    new BaseballCard()
                    {
                         Id=2,
                         PlayerName = "Micky Mantle",
                         Location = "Red box in Attic",
                         Team = "New York Yankees",
                         Year = 1952,
                         UserId = 2,
                         Image = "/Images/Mickey_Mantle1952.jpg"
                    },
                    new BaseballCard()
                    {
                         Id=3,
                         PlayerName = "Micky Mantle",
                         Location = "Red box in Attic",
                         Team = "New York Yankees",
                         Year = 1952,
                         UserId = 3,
                         Image = "/Images/Mickey_Mantle1952.jpg"
                    }
                });
            });
        }
    }
}

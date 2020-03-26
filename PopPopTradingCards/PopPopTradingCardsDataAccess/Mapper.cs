using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Models;
using PopPopTradingCardsDataAccess.Entities;
using Lib = PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsDataAccess
{
    public class Mapper
    {
        public static PopPopTradingCardsLib.Models.User Map(Entities.User u)
        {
            PopPopTradingCardsLib.Models.User user = new PopPopTradingCardsLib.Models.User()
            {
                Password = u.Password,
                Username = u.Username,
                Id = u.Id
            };
            return user;
        }

        public static Lib.MagicCard Map(Entities.MagicCard c)
        {
            Lib.MagicCard card = new Lib.MagicCard()
            {
                Id = c.Id,
                UserId = c.UserId,
                Name = c.Name,
                Color = c.Color,
                CMC = c.CMC,
                Type = c.Type,
                Rarity = c.Rarity,
                Booster = c.Booster,
                Image = c.Image,
                Location = c.Location
            };
            return card;
        }
        public static Lib.BaseballCard Map(Entities.BaseballCard c)
        {
            Lib.BaseballCard card = new Lib.BaseballCard()
            {
                Id = c.Id,
                UserId = c.UserId,
                PlayerName = c.PlayerName,
                Team = c.Team,
                Year = c.Year,
                Image = c.Image,
                Location = c.Location
            };
            return card;
        }

        public static Entities.MagicCard Map(Lib.MagicCard c)
        {
            Entities.MagicCard card = new Entities.MagicCard()
            {
                Id = c.Id,
                UserId = c.UserId,
                Name = c.Name,
                Color = c.Color,
                CMC = c.CMC,
                Type = c.Type,
                Rarity = c.Rarity,
                Booster = c.Booster,
                Image = c.Image,
                Location = c.Location
            };
            return card;
        }

        public static Entities.BaseballCard Map(Lib.BaseballCard c)
        {
            Entities.BaseballCard card = new Entities.BaseballCard()
            {
                Id = c.Id,
                UserId = c.UserId,
                PlayerName = c.PlayerName,
                Team = c.Team,
                Year = c.Year,
                Image = c.Image,
                Location = c.Location
            };
            return card;
        }
    }
}

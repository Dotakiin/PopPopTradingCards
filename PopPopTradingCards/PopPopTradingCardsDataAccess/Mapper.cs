using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Models;
using PopPopTradingCardsDataAccess.Entities;

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
    }
}

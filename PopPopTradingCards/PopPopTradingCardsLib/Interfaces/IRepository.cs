using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Models;
using Lib = PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsLib.Interfaces
{
    public interface IRepository
    {
        public void CreateAccount(string name, string pass);
        public User Login(string name, string pass);
        public bool CheckAvailability(string name);
        IEnumerable<MagicCard> GetMagicCards();
        IEnumerable<BaseballCard> GetBaseballCards();
        MagicCard GetMagicCard(int id);
        BaseballCard GetBaseballCard(int id);
        void PostMagicCard(MagicCard card);
        void PostBaseballCard(BaseballCard card);
        void PutMagicCard(MagicCard card);
        void PutBaseballCard(BaseballCard card);
        void DeleteMagicCard(int id);
        void DeleteBaseballCard(int id);
    }
}

using System.Collections.Generic;
using PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsLib.Interfaces
{
    public interface IRepository
    {
        public void CreateAccount(string name, string pass);
        public int Login(string name, string pass);
        public bool CheckAvailability(string name);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        IEnumerable<MagicCard> GetMagicCards();
        IEnumerable<MagicCard> GetMagicCards(int? id);
        IEnumerable<BaseballCard> GetBaseballCards();
        IEnumerable<BaseballCard> GetBaseballCards(int? id);
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

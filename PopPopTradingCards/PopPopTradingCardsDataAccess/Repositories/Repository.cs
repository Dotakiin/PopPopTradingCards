using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Interfaces;
using System.Linq;
using Entity = PopPopTradingCardsDataAccess.Entities;
using Lib = PopPopTradingCardsLib.Models;
using PopPopTradingCardsDataAccess.Entities;

namespace PopPopTradingCardsDataAccess.Repositories
{
    public class Repository : IRepository
    {
        private readonly PopPopTradingCardsDbContext _context;

        // constructor
        public Repository(PopPopTradingCardsDbContext db)
        {
            // inject the database
            _context = db ?? throw new ArgumentNullException(nameof(db), "Context cannot be null.");
        }

        public bool CheckAvailability(string name)
        {
            List<string> names = new List<string>();
            IQueryable<User> users = _context.User;
            users = users.Where(x => x.Username == name);
            int count = users.Count();
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateAccount(string name, string pass)
        {
            if (CheckAvailability(name))
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(pass);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);
                User newUser = new User()
                {
                    Username = name,
                    Password = hash,
                };
                _context.Add<User>(newUser);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("That username is taken.");
            }
        }

        public int Login(string name, string pass)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(pass);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            IQueryable<User> users = _context.User;
            users = users.Where(x => x.Username == name && x.Password == hash);
            if (users.Count() == 0)
            {
                return 0;
            }
            else
            {
                User u = users.First();
                return u.Id;
            }
        }

        public IEnumerable<Lib.User> GetAllUsers()
        {
            var e_users = _context.User.ToList<Entities.User>();
            var l_users = new List<Lib.User>();

            foreach (var user in e_users)
            {
                var l_user = Mapper.Map(user);
                l_users.Add(l_user);
            }

            return l_users;
        }

        // Get reference to a user by a given id
        public Lib.User GetUserById(int id)
        {
            var e_user = _context.User.Where(u => u.Id == id).FirstOrDefault();
            return Mapper.Map(e_user);
        }

        public IEnumerable<Lib.MagicCard> GetMagicCards()
        {
            var e_cards = _context.MagicCard.ToList<Entities.MagicCard>();
            var l_cards = new List<Lib.MagicCard>();

            foreach(Entities.MagicCard card in e_cards)
            {
                var l_card = Mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }
        public IEnumerable<Lib.MagicCard> GetMagicCards(int? id)
        {
            var e_cards = _context.MagicCard.Where(x=>x.UserId==id).ToList<Entities.MagicCard>();
            var l_cards = new List<Lib.MagicCard>();

            foreach (Entities.MagicCard card in e_cards)
            {
                var l_card = Mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }

        public IEnumerable<Lib.BaseballCard> GetBaseballCards()
        {
            var e_cards = _context.BaseballCard.ToList<Entities.BaseballCard>();
            var l_cards = new List<Lib.BaseballCard>();

            foreach(Entities.BaseballCard card in e_cards)
            {
                var l_card = Mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }
        public IEnumerable<Lib.BaseballCard> GetBaseballCards(int? id)
        {
            var e_cards = _context.BaseballCard.Where(x=>x.UserId==id).ToList<Entities.BaseballCard>();
            var l_cards = new List<Lib.BaseballCard>();

            foreach (Entities.BaseballCard card in e_cards)
            {
                var l_card = Mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }

        public Lib.MagicCard GetMagicCard(int id)
        {
            var e_card = _context.MagicCard.SingleOrDefault(x => x.Id == id);
            var l_card = Mapper.Map(e_card);
            return l_card;
        }

        public Lib.BaseballCard GetBaseballCard(int id)
        {
            var e_card = _context.BaseballCard.SingleOrDefault(x => x.Id == id);
            var l_card = Mapper.Map(e_card);
            return l_card;
        }

        public void PostMagicCard(Lib.MagicCard card)
        {
            var e_card = Mapper.Map(card);
            _context.MagicCard.Add(e_card);
            _context.SaveChanges();
        }

        public void PostBaseballCard(Lib.BaseballCard card)
        {
            var e_card = Mapper.Map(card);
            _context.BaseballCard.Add(e_card);
            _context.SaveChanges();
        }

        public void PutMagicCard(Lib.MagicCard card)
        {
            var e_card = Mapper.Map(card);
            _context.MagicCard.Update(e_card);
            _context.SaveChanges();
        }

        public void PutBaseballCard(Lib.BaseballCard card)
        {
            var e_card = Mapper.Map(card);
            _context.BaseballCard.Update(e_card);
            _context.SaveChanges();
        }

        public void DeleteMagicCard(int id)
        {
            var card = _context.MagicCard.SingleOrDefault(x => x.Id == id);
            _context.MagicCard.Remove(card);
            _context.SaveChanges();
        }

        public void DeleteBaseballCard(int id)
        {
            var card = _context.BaseballCard.SingleOrDefault(x => x.Id == id);
            _context.BaseballCard.Remove(card);
            _context.SaveChanges();
        }
    }
}

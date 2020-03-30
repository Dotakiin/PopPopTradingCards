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

        // the mapper tool
        private readonly IMapper _mapper;

        // constructor
        public Repository(PopPopTradingCardsDbContext db, IMapper mapper)
        {
            // inject the database
            _context = db ?? throw new ArgumentNullException(nameof(db), "Context cannot be null.");

            // instantiate the mapper
            _mapper = mapper;
        }

        public bool CheckAvailability(string name)
        {
            List<string> names = new List<string>();
            IQueryable<User> users = _context.Users;
            users = users.Where(x => x.Username == name);
            if (users.Count() == 0)
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
            }
            else
            {
                throw new ArgumentException("That username is taken.");
            }
        }

        public PopPopTradingCardsLib.Models.User Login(string name, string pass)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(pass);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            IQueryable<User> users = _context.Users;
            users = users.Where(x => x.Username == name && x.Password == hash);
            User user = users.FirstOrDefault();
            return Mapper.Map(user);
        }

        public IEnumerable<Lib.MagicCard> GetMagicCards()
        {
            var e_cards = _context.MagicCards.ToList<Entities.MagicCard>();
            var l_cards = new List<Lib.MagicCard>();

            foreach(Entities.MagicCard card in e_cards)
            {
                var l_card = _mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }

        public IEnumerable<Lib.BaseballCard> GetBaseballCards()
        {
            var e_cards = _context.BaseballCards.ToList<Entities.BaseballCard>();
            var l_cards = new List<Lib.BaseballCard>();

            foreach(Entities.BaseballCard card in e_cards)
            {
                var l_card = Mapper.Map(card);
                l_cards.Add(l_card);
            }

            return l_cards;
        }

        public Lib.MagicCard GetMagicCard(int id)
        {
            var e_card = _context.MagicCards.SingleOrDefault(x => x.Id == id);
            var l_card = _mapper.Map(e_card);
            return l_card;
        }

        public Lib.BaseballCard GetBaseballCard(int id)
        {
            var e_card = _context.BaseballCards.SingleOrDefault(x => x.Id == id);
            var l_card = _mapper.Map(e_card);
            return l_card;
        }

        public void PostMagicCard(Lib.MagicCard card)
        {
            var e_card = _mapper.Map(card);
            _context.MagicCards.Add(e_card);
            _context.SaveChanges();
        }

        public void PostBaseballCard(Lib.BaseballCard card)
        {
            var e_card = _mapper.Map(card);
            _context.BaseballCards.Add(e_card);
            _context.SaveChanges();
        }

        public void PutMagicCard(Lib.MagicCard card)
        {
            var e_card = _mapper.Map(card);
            _context.MagicCards.Update(e_card);
            _context.SaveChanges();
        }

        public void PutBaseballCard(Lib.BaseballCard card)
        {
            var e_card = _mapper.Map(card);
            _context.BaseballCards.Update(e_card);
            _context.SaveChanges();
        }

        public void DeleteMagicCard(int id)
        {
            var card = _context.MagicCards.SingleOrDefault(x => x.Id == id);
            _context.MagicCards.Remove(card);
            _context.SaveChanges();
        }

        public void DeleteBaseballCard(int id)
        {
            var card = _context.BaseballCards.SingleOrDefault(x => x.Id == id);
            _context.BaseballCards.Remove(card);
            _context.SaveChanges();
        }
    }
}

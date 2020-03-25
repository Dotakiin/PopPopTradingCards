using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Interfaces;
using System.Linq;
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsLib.Interfaces
{
    public interface IRepository
    {
        public void CreateAccount(string name, string pass);
        public User Login(string name, string pass);
        public bool CheckAvailability(string name);
    }
}

using PopPopTradingCardsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopPopTradingCardsWebUI.Models
{
    public class OtherCollectionViewModel
    {
        public string Username { get; set; }
        public IEnumerable<MagicCard> MagicCards { get; set; }
        public IEnumerable<BaseballCard> BaseballCards { get; set; }
    }
}

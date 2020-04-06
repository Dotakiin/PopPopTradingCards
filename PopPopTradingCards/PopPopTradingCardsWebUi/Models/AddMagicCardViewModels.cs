using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopPopTradingCardsWebUI.Models
{
    public class AddMagicCardViewModels
    {
        public int id { get; set; }
        public List<PopPopTradingCardsLib.Models.MagicCard> MagicCards { get; set; }
        public string Location { get; set; }
    }
}

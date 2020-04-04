using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopPopTradingCardsWebUI.Models
{
    public class MagicCard
    {
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int CMC { get; set; }
		public string Type { get; set; }
		public string Rarity { get; set; }
		public string Booster { get; set; }
		public string Image { get; set; }
		public string Location { get; set; }
	}
}

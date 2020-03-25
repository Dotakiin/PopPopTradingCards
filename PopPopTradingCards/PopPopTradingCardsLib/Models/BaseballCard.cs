using System;
using System.Collections.Generic;
using System.Text;

namespace PopPopTradingCardsLib.Models
{
	public class BaseballCard
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string PlayerName { get; set; }

		public string Team { get; set; }

		public int Year { get; set; }

		public string Image { get; set; }

		public string Location { get; set; }
	}

}

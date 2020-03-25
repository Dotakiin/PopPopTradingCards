using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopPopTradingCards.Entities
{
	[Table("User", Schema = "TradingCardTracker")]
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		public virtual ICollection<MagicCard> MagicCards { get; set; }
		public virtual ICollection<BaseballCard> BaseballCards { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopPopTradingCardsDataAccess.Entities
{
	public class MagicCard
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		[Required]
		public string Name { get; set; }

		public string Color { get; set; }

		public int CMC { get; set; }

		public string Type { get; set; }

		public string Rarity { get; set; }

		public string Booster { get; set; }

		public string Image { get; set; }

		public string Location { get; set; }

		public virtual User User { get; set; }
	}
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseballCard
{
	public BaseballCard()
	{
	}

	[Required]
	public int Id { get; set; }

	[ForeignKey("User")]
	public int UserId { get; set; }

	[Required]
	public string PlayerName { get; set; }

	public string Team { get; set; }

	public int Year { get; set; }

	public string Image { get; set; }

	public string Location { get; set; }

	public User User { get; set; }
}

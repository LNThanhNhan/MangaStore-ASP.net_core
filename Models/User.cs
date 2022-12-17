using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaStore.Models
{
	public class User
	{
		[Key]
		public int id { get; set; }
		[Required]
		public int account_id { get; set; }
		public Account account { get; set; }
		[Required]
		[MaxLength(100)]
		public string name { get; set; }
		[Required]
		public int gender { get; set; }
		[MaxLength(10)]
		public string? phone { get; set; }
		public string? address { get; set; }
		public int? province { get; set; }
		
		public Cart cart { get; set; }
	}
}

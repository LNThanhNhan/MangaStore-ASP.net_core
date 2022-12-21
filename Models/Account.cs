using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MangaStore.Models
{
	[Index(nameof(email), IsUnique = true)]
	public class Account
	{
		[Key]
		public int id { get; set; }
		[Required]
		[MaxLength(100)]
		public string username {get; set;}
		[Required]
		[MaxLength(255)]
		public string password { get; set; }
		[Required]
		[MaxLength(100)]
		public string email { get; set; }
		[Required]
		[DefaultValue(0)]
		public int role { get ; set; }
		
		public User user { get; set; }
	}
}

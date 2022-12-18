using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MangaStore.ViewModels;

namespace MangaStore.Models
{
    [Index(nameof(name), IsUnique = true)]
    [Index(nameof(slug), IsUnique = true)]
    public class Product
    {
		[Key]
        public int id { get; set; }

        [Required]
        //Thêm index unique cho cột name
        [MaxLength(255)]
        public string name { get; set; }

        [Required]
        [MaxLength(255)]
        public string slug { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        [MaxLength(100)]
        public string author { get; set; }

        [Required]
        [MaxLength(100)]
        public string author_slug { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long list_price { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long price { get; set; }

        [Required]
        public int discount_rate { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public int publish_year { get; set; }

        [Required]
        [MaxLength(30)]
        public string size { get; set; }

        [MaxLength(255)]
        public string? collection { get; set; }

        [MaxLength(255)]
        public string? collection_slug { get; set; }

        [Required]
        public int category { get; set; }
        
        public List<CartDetail> cart_details { get; set; }
        public List<Sample> samples { get; set; }
    }
}

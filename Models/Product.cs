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
		/*public Product()
		{
		}
		public Product(ProductViewModel pd)
        {
            name = pd.name;
            slug = pd.slug;
            image = pd.image;
            description = pd.description;
            author = pd.author;
            author_slug = pd.author_slug;
            list_price = pd.list_price;
            price = pd.price;
            discount_rate = pd.discount_rate;
            quantity = pd.quantity;
            publish_year = pd.publish_year;
            size = pd.size;
            collection = pd.collection;
            collection_slug = pd.collection_slug;
            category = pd.category;
        }

		public Product(EditProductViewModel pd)
		{
			name = pd.name;
			slug = pd.slug;
			image = pd.image;
			description = pd.description;
			author = pd.author;
			author_slug = pd.author_slug;
			list_price = pd.list_price;
			price = pd.price;
			discount_rate = pd.discount_rate;
			quantity = pd.quantity;
			publish_year = pd.publish_year;
			size = pd.size;
			collection = pd.collection;
			collection_slug = pd.collection_slug;
			category = pd.category;
		}*/

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
    }
}

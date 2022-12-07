using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MangaStore.Models
{
    [Index(nameof(name),IsUnique = true)]
    [Index(nameof(slug),IsUnique = true)]
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
        //Data annotation cho kiểu mặc định là nvarchar(max) trong sql server
        public string description { get; set; }
        
        [Required]
        [Column(TypeName = "bigint")]
        public long list_price { get; set; }
        
        [NotMapped]
        //Làm thuộc tính chuyển giá niêm yết sang vnđ
        public string list_priceVND
        {
            get
            {
                return list_price.ToString("N0") + " đ";
            }
        }

        [Required]
        [Column(TypeName = "bigint")]
        public long price { get; set; }
        
        [NotMapped]
        //Làm thuộc tính chuyển giá sang tiền tệ vnđ
        public string priceVND { get { return price.ToString("N0") + " đ"; } }
        
        [Required]
        public int discount_rate { get; set; }
        
        [Required]
        public int quantity { get; set; }
        
        [Required]
        public int publish_year { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string size { get; set; }

        [MaxLength(50)]
        public string? collection{ get; set; }

        [MaxLength(50)]
        public string? collection_slug { get; set; }

        [Required]
        public int category { get; set; }
    }
}

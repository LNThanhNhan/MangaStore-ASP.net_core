using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaStore.Models;

public class Order
{
    [Key]
    public int id { get; set; }
    
    public int user_id { get; set; }
    
    public User user { get; set; }
    
    [MaxLength(100)]
    public string name { get; set; }
    
    [MaxLength(100)]
    public string email { get; set; }
    
    [MaxLength(10)]
    public string phone { get; set; }
    public string address { get; set; }
    public int province { get; set; }
    public int status { get; set; }
    public int payment_method { get; set; }
    
    [Column(TypeName = "bigint")]
    public long total_order { get; set; }
    
    [Column(TypeName = "bigint")]
    public long delivery_fee { get; set; }
    
    [Column(TypeName = "bigint")]
    public long total_price { get; set; }
    
    public DateTime order_date { get; set; }
    public DateTime? delivery_date { get; set; }
    
    public List<OrderDetail> order_details { get; set; }
}
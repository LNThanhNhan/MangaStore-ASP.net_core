using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaStore.Models;

public class OrderDetail
{
    public int order_id { get; set; }
    public Order Order { get; set; }
    public int product_id { get; set; }
    public Product product { get; set; }
    public int quantity { get; set; }
    [Column(TypeName = "bigint")]
    public long price { get; set; }
    [Column(TypeName = "bigint")]
    public long total_price { get; set; }
}
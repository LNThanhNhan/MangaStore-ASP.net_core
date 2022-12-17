namespace MangaStore.Models;

public class CartDetail
{
    public int cart_id { get; set; }
    public Cart cart{ get; set; }
    public int product_id { get; set; }
    public Product product { get; set; }
    public int quantity { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace MangaStore.Models;

public class Cart
{
    [Key]
    public int id { get; set; }
    public int user_id { get; set; }
    public User user { get; set; }
    public List<CartDetail> cart_details { get; set; }
}
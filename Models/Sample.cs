using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MangaStore.Models;
public class Sample
{
    [Key]
    public int id { get; set; }
    public int product_id { get; set; }
    public Product product { get; set; }
    public string image { get; set; } 
}
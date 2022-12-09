using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using MangaStore.Models;

namespace MangaStore.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        
    }
}

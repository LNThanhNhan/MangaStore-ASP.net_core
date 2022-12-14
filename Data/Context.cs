using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using MangaStore.Models;

namespace MangaStore.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
        public DbSet<Product> Products { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasOne<Account>(u=> u.account)
				.WithOne(a => a.user)
				.HasForeignKey<User>(u => u.account_id)
				.HasPrincipalKey<Account>(a => a.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			modelBuilder.Entity<Account>()
				.HasOne<User>(a => a.user)
				.WithOne(a => a.account)
				.HasForeignKey<User>(u => u.account_id)
				.HasPrincipalKey<Account>(a => a.id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

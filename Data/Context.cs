﻿using Microsoft.EntityFrameworkCore;
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
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartDetail> CartDetails { get; set; }
		public DbSet<Sample> Sample { get; set; }
		
		public DbSet<Order> Orders { get; set; }
		
		public DbSet<OrderDetail> OrderDetails { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasOne<Account>(u=> u.account)
				.WithOne(a => a.user)
				.HasForeignKey<User>(u => u.account_id)
				.HasPrincipalKey<Account>(a => a.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//thiết lập quan hệ 1:1 giữa user và cart và set delete behavior
			//là casecade, tức là khi xóa user thì cart cũng bị xóa
			modelBuilder.Entity<User>()
				.HasOne<Cart>(u => u.cart)
				.WithOne(c => c.user)
				.HasForeignKey<Cart>(c => c.user_id)
				.HasPrincipalKey<User>(u => u.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//Thiết lập khóa chính cho bảng cart_detail
			//với khóa chính là 2 khóa ngoại cart_id và product_id
			modelBuilder.Entity<CartDetail>()
				.HasKey(cd => new { cd.cart_id, cd.product_id });
			
			//thiết lập quan hệ 1:n giữa cart và cart detail
			//và set delete behavior là casecade
			//tức là khi xóa cart thì cart detail cũng bị xóa
			modelBuilder.Entity<Cart>()
				.HasMany<CartDetail>(c => c.cart_details)
				.WithOne(cd => cd.cart)
				.HasForeignKey(cd => cd.cart_id)
				.HasPrincipalKey(c => c.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//Thiết lập quan hệ 1:n giữa product và cart detail
			//và set delete behavior là casecade
			//tức là khi xóa product thì cart detail cũng bị xóa
			modelBuilder.Entity<Product>()
				.HasMany<CartDetail>(p => p.cart_details)
				.WithOne(cd => cd.product)
				.HasForeignKey(cd => cd.product_id)
				.HasPrincipalKey(p => p.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//Thiết lập quan hệ 1:n giữa product và sample
			//và set delete behavior là casecade
			//tức là khi xóa product thì sample cũng bị xóa
			modelBuilder.Entity<Product>()
				.HasMany<Sample>(p => p.samples)
				.WithOne(s => s.product)
				.HasForeignKey(s => s.product_id)
				.HasPrincipalKey(p => p.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//Thiết lập khóa chính cho bảng order_detail
			//với khóa chính là 2 khóa ngoại order_id và product_id
			modelBuilder.Entity<OrderDetail>()
				.HasKey(od => new { od.order_id, od.product_id });
			
			//thiết lập quan hệ 1:n giữa User và Order
			//và set delete behavior là casecade
			//tức là khi xóa Order thì Order cũng bị xóa
			modelBuilder.Entity<User>()
				.HasMany<Order>(u => u.orders)
				.WithOne(o => o.user)
				.HasForeignKey(o => o.user_id)
				.HasPrincipalKey(u => u.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//thiết lập quan hệ 1:n giữa Order và Order detail
			//và set delete behavior là casecade
			//tức là khi xóa Order thì Order detail cũng bị xóa
			modelBuilder.Entity<Order>()
				.HasMany<OrderDetail>(o => o.order_details)
				.WithOne(od => od.Order)
				.HasForeignKey(od => od.order_id)
				.HasPrincipalKey(o => o.id)
				.OnDelete(DeleteBehavior.Cascade);
			
			//thiết lập quan hệ 1:n giữa product và Order detail
			//và set delete behavior là casecade
			//tức là khi xóa product thì Order detail cũng bị xóa
			modelBuilder.Entity<Product>()
				.HasMany<OrderDetail>(p => p.order_details)
				.WithOne(od => od.product)
				.HasForeignKey(od => od.product_id)
				.HasPrincipalKey(p => p.id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

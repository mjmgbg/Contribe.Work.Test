using Contribe.Ecommerce.Models;
using System.Data.Entity;

namespace Contribe.Ecommerce.Data
{
	public class EcommerceContext : DbContext
	{
		public EcommerceContext()
			: base("EcommerceContext")
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{


			modelBuilder.Entity<Book>()
				.Ignore(b => b.IsInDb);

		}
		public static EcommerceContext Create()
		{
			return new EcommerceContext();
		}
	}
}
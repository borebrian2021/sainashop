using Microsoft.EntityFrameworkCore;
using SAINA.Models;
using SHOP.Models;

namespace Lubes.DBContext
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<shop_items> Shop_items { get; set; }

		public DbSet<Restock_history> Restock_history { get; set; }

		public DbSet<log_in> Log_in { get; set; }

		public DbSet<sold_items> sold_items { get; set; }
		public DbSet<Creditors_account> Creditors { get; set; }
		public DbSet<Credits> Credits { get; set; }
		public DbSet<Payment_history> Payment_history { get; set; }
		public DbSet<Expiries> Expiries { get; set; }
		public DbSet<Suppliers> Supliers { get; set; }
		public DbSet<Settings> Settings { get; set; }



		/// System 2
		/// 
		public DbSet<Clients> Clients { get; set; }
		public DbSet<Deliveries> Deliveries { get; set; }
		public DbSet<Invoices> Invoices { get; set; }
		public DbSet<Particulars> Particulars { get; set; }
		public DbSet<Receipts2> Receipts { get; set; }
	
		public DbSet<Log_in2> Log_in2{ get; set; }

		/// </summary>
		/// <param name="options"></param>
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
		}
	}
}

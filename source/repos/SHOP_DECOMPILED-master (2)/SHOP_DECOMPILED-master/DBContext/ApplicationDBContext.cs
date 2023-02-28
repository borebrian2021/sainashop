using Microsoft.EntityFrameworkCore;
using SHOP.Models;
using SHOP_DECOMPILED.Models;

namespace Lubes.DBContext
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<shop_items> Shop_items { get; set; }
		public DbSet<Restock_history> Restock_history { get; set; }
		public DbSet<log_in> Log_in { get; set; }
		public DbSet<sold_items> sold_items { get; set; }
		public DbSet<Creditors_account> Creditors { get; set; }
		public DbSet<Creditors_account_fuel> Creditors_fuel { get; set; }
		public DbSet<Payment_history_fuel> Payment_history_fuel { get; set; }
		public DbSet<Credits> Credits { get; set; }
		public DbSet<Credits_fuel> Credits_fuel { get; set; }
		public DbSet<Payment_history> Payment_history { get; set; }
		public DbSet<Expiries> Expiries { get; set; }
		public DbSet<Suppliers> Supliers { get; set; }
		public DbSet<Settings> Settings { get; set; }
		public DbSet<System_users> System_users { get; set; }
		public DbSet<Expenses> Expenses { get; set; }
		public DbSet<Fuel_category> Fuel_category { get; set; }
		public DbSet<General_sales_history> General_sales_history { get; set; }
		public DbSet<Individual_fuel_Sales_history> Individual_fuel_Sales_history { get; set; }
		public DbSet<Meter_readings> Meter_readings { get; set; }
		public DbSet<SMS_Config> SMS_Config { get; set; }
		public DbSet<Refill_history> Refill_history { get; set; }
		public DbSet<Fuel_station_reg> Fuel_station_reg { get; set; }
		public DbSet<SMS_Settings> SMS_Settings { get; set; }



		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
		}
	}
}

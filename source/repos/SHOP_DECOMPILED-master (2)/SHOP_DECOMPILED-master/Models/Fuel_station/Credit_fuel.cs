using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class Credits_fuel
	{
		[Key]
		public int id { get; set; }
		public int Client_id { get; set; }
		public string Fuel { get; set; }
		public string Ammount_in_litres { get; set; }
		public double Total { get; set; }
		public string Number_plate { get; set; }
		public int station_id { get; set; }
		public string Date_created { get; set; }
	}
}

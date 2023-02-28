using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHOP.Models
{
	public class SMS_Settings
	{
		[Key]
		public int id { get; set; }
		public string Fuel_id { get; set; }
		public double Level { get; set; } = 0;
		public string status  { get; set; } 
		public string Last_set { get; set; }

	}
}

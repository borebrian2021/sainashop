using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class Payment_history
	{
		[Key]
		public int id { get; set; }
		public int Client_id { get; set; }
		public double Ammount_paid { get; set; }
		public double Balance { get; set; }
		public string Date_created { get; set; }
	}
}

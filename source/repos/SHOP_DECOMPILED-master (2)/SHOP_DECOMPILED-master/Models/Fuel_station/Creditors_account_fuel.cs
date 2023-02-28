using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class Creditors_account_fuel
	{
		[Key]
		public int id { get; set; }

		[Display(Name = "Full names:", Prompt = "Full Names:")]
		[DataType(DataType.Currency)]
		[Required]
		public string Customer_name { get; set; }
		[Display(Name = "Phone number:", Prompt = "Phone number:")]
		[DataType(DataType.Currency)]
		[Required]
		public int Phone_number { get; set; }
		public int station_id { get; set; }
		public double Balance { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public string Date_created { get; set; }
	}
}

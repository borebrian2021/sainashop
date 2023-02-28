using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class sold_items
	{
		[Key]
		public int id { get; set; }

		public int Item_id { get; set; }

		public double quantity_sold { get; set; }

		public double Total_cash_made { get; set; }

		public double Cost_cash{ get; set; }
		public double Total_Cost_cash{ get; set;}
		public double Profit{ get; set; }

		[Required]
		[DataType(DataType.Date)]
		public string DateTime { get; set; }
	}
}

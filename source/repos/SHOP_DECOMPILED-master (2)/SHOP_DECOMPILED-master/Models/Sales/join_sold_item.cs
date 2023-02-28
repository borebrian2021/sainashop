using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class join_sold_item
	{
		public string Item_id { get; set; }

		public string Item_name { get; set; }

		public double Item_price { get; set; }
		public double Total_Cost_cash { get; set; }


		public double quantity_sold { get; set; }

		public double Total_cash_made { get; set; }
		public double id { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public string DateTime { get; set; }
	}
}

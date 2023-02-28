using System.ComponentModel.DataAnnotations;

namespace SHOP.Models
{
	public class shop_items
	{
		[Key]
		public int id { get; set; }

		[Display(Name = "Item name:", Prompt = "Item name")]
		[DataType(DataType.Currency)]
		[Required]
		public string Item_name { get; set; }

		[Display(Name = "Item price:", Prompt = "Price in Ksh.")]
		[DataType(DataType.Currency)]
		[Required]
		public double Item_price { get; set; }

		[Display(Name = "Item quantity:", Prompt = "Quantity")]
		[Required]
		public double Quantity { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public string DateTime { get; set; }
	
		public double Cost_price { get; set; }
	}
}

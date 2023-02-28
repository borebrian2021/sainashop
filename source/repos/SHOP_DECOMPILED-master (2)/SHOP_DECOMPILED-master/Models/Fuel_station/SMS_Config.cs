using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHOP.Models
{
	public class SMS_Config
	{
		[Key]
		public int id { get; set; }
		public string SSD { get; set; }
		public string Token { get; set; }
		public string Phone { get; set; } 
		
	}
}

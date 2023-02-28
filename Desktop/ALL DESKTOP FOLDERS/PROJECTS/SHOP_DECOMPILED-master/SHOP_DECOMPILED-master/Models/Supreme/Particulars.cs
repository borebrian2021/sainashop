using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
    public class Particulars
	{
		
		[Key]
		public int id { get; set; }
		public int client_id { get; set; }
		public int delivery_no { get; set; }


		[Required]
		public bool category { get; set; }



		[Required]
		public int Quantity { get; set; }

	
		public int price { get; set; }
		
		
		[Required]
		public string  Item_name { get; set; }


		[Required]
		public float total { get; set; }


		//public string Password { get; set; }
			
			
		}
	

}


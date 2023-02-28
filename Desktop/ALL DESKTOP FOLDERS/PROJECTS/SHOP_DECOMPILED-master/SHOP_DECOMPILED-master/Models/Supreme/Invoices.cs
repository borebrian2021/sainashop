using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
	
    public class Invoices
    {
		public static Random x = new Random();

		[Key]
			public int id { get; set; }
			[Required]

			public int client_id { get; set; }



			public int LPO_Number { get; set; }

		[Required]
	
		public int Delivery_no { get; set; } 

			[Required]
			public string M_s { get; set; }

			[Required]
			public string date { get; set; }


		public float Total { get; set; } = 0;
			
			
		}
	

}


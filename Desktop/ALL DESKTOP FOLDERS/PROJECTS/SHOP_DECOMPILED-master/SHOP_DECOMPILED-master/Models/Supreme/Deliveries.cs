using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
    public class Deliveries
    {
		
			[Key]
			public int id { get; set; }
			public int client_id { get; set; }

			[Required]
			public int LPO_Number { get; set; }
			
		


		[Required]
		public int D_Number { get; set; }

			[Required]
			public string M_s { get; set; }

			[Required]
			public string date { get; set; }
		
			[Required]
			public string Received_by { get; set; }
		
			[Required]
			public string Delivered_by { get; set; }

		public float Total { get; set; }
			
			
		}
	

}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
    public class Receipts2
    {
			[Key]
			public int id { get; set; }
			public int client_id { get; set; }

			[Required]
			public string Received_from { get; set; }
		
			[Required]
			public string Date { get; set; }

			[Required]
			public float Total { get; set; }

			[Required]
			public float Balance { get; set; }

			[Required]
			public string Particulars { get; set; }
			
			public string check_number { get; set; }
		
			[Required]
			public bool Payment_mode { get; set; }
		
			
			
		}
	

}


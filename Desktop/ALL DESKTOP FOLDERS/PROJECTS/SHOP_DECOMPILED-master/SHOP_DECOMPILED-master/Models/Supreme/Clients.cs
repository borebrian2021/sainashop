using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
    public class Clients
    {
		
		[Key]
		public int id { get; set; }

		[Required]
		public string Phone_number { get; set; }
		[Required]

		public string Client_name { get; set; }
		[Required]	

		public string date { get; set; }
		[Required]

		public float account_balance { get; set; }
		public string Password { get; set; }
			
			
		}
	

}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAINA.Models
{
    public class Log_in2
    {
		
			[Key]
			public int id { get; set; }


			public string Phone_number { get; set; }
			public string Shop_name { get; set; }


			public int User_id { get; set; }
			public string Password { get; set; }
			
			
		}
	

}


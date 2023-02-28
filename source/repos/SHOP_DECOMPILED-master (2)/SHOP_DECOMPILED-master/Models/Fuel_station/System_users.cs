using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class System_users
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Full names", Prompt = "Full names")]
        public string Full_name { get; set; }

        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
         [Required]
        [Display(Name = "Password", Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Natioanl ID", Prompt = "National ID")]
        public int National_id { get; set; }
        public int station_id { get; set; }

        [Required]
        [Display(Name = "Role", Prompt = "Role")]
        public int Roles { get; set; }
    }
}

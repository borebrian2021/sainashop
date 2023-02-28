using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Fuel_category
    {
        [Key]
        public int id { get; set; }
        public int fuel_id { get; set; }

        public int Station_id { get; set; }

        [Required]
        [Display(Name = "Fuel type", Prompt = "Fuel type")]
        public string Fuel_names { get; set; }

        [Required]
        [Display(Name = "Tank capacity ltrs", Prompt = "Tank capacity ltrs")]
        public double Tank_capacity { get; set; }

        [Required]
        [Display(Name = "Dippings", Prompt = "Dippings")]
        [DataType(DataType.Text)]
        public double Current_quantity { get; set; }

        [Required]
        [Display(Name = "Price", Prompt = "Price")]
        public double Price { get; set; }

        //[Required]
        //[Display(Name = "Role", Prompt = "Role")]
        //public int Roles { get; set; }
    }
}

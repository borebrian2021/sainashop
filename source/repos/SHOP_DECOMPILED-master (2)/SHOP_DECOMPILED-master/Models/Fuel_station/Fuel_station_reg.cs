using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Fuel_station_reg
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Owners ID", Prompt = "Owners id number")]
        public string Owners_id { get; set; }

        [Required]
        [Display(Name = "Station name", Prompt = "Station name")]
        [DataType(DataType.Text)]
        public string Station_Name { get; set; }
         [Required]
        [Display(Name = "Location", Prompt = "Location")]
        [DataType(DataType.Text)]
        public string Location { get; set; }
    }
}

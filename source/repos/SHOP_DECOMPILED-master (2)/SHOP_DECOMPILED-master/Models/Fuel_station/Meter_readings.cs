using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class    Meter_readings
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Fuel id", Prompt = "Fuel id")]
        public int Fuel_id { get; set; }  
        
        
        [Required]
        [Display(Name = "Fuel dispenser lebel", Prompt = "Fuel Dispenser lebel")]
        public string Label { get; set; }      
        
        [Required]
        [Display(Name = "Station id", Prompt = "Station id")]
        public int Station_id { get; set; }

        [Required]
        [Display(Name = "Current meter", Prompt = "Current readings")]
        public double Current_readings { get; set; }
        
        [Required]
        [Display(Name = "Previous Readings", Prompt = "Previous readings")]
        public double Previous_readings { get; set; }

        [Required]
        [Display(Name = "Date", Prompt = "Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        //[Required]
        [Display(Name = "Agent id", Prompt = "Agent id")]
        public double Agent_id { get; set; } = 0;

        
    }
}

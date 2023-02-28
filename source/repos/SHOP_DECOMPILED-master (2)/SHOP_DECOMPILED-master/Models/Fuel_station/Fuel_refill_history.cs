using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Refill_history
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Fuel_id", Prompt = "Fuel_id")]
        public int Fuel_id { get; set; }

        [Required]
        [Display(Name = "Ammount refilled", Prompt = "Ammount_refilled")]
        public double Ammount_refilled { get; set; }

        [Required]
        [Display(Name = "Date refilled", Prompt = "Date refilled")]
        [DataType(DataType.Date)]
        public string Date_refilled { get; set; }

        [Required]
        [Display(Name = "Initial readings", Prompt = "Initial readings")]
        public double initial_readings { get; set; }

        [Required]
        [Display(Name = "Final readings", Prompt = "Final readings")]
        public double final_readings { get; set; }
        [Required]
        [Display(Name = "Agent id", Prompt = "Agent id")]
        public int agent_id { get; set; }

        //[Required]
        //[Display(Name = "Role", Prompt = "Role")]
        //public int Roles { get; set; }
    }
}

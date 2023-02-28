using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Individual_fuel_Sales_history
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Date { get; set; }
        public int Fuel_id { get; set; }       
        public int Station_id { get; set; }       
        public int Dispenser_id { get; set; }       
        public double Previous_meter { get; set; }
        public double Closing_meter { get; set; }
        public double Litres_sold { get; set; }
        public double Price { get; set; }
        public double Remaining_fuel { get; set; }
        public double Cash_made { get; set; }
        public string Attendant { get; set; }
    }
}

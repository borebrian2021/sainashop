using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Relationship_meter_sales
    {
        [Key]
        public int fuel_id { get; set; }
        public int Station_id { get; set; }
        public string Fuel_names { get; set; }
        public double Tank_capacity { get; set; }
        public double Current_quantity { get; set; }
        //METER READINGS 
        public string Label { get; set; }
        public double Current_readings { get; set; }
        public double Previous_readings { get; set; }
        public double Agent_id { get; set; }
        //SALES
        public int id { get; set; }
        [Required]
        public string Date { get; set; }
        public int Fuel_id { get; set; }
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

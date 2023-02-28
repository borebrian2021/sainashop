using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Relationship_meter
    {
        [Key]
        public int id { get; set; }
        public int f_id { get; set; }
        public int fuel_id { get; set; }
        public int Station_id { get; set; }
        public string Fuel_names { get; set; }
        public double Tank_capacity { get; set; }
        public double Current_quantity { get; set; }
        public double Price { get; set; }
        //METER READINGS 
        public string Label { get; set; }
        public double Current_readings { get; set; }
        public double Previous_readings { get; set; }
        public string Date { get; set; }
        public double Agent_id { get; set; }
    }
}

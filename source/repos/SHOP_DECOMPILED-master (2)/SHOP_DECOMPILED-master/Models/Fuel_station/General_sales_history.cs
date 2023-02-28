using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class General_sales_history
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int Attendant_id { get; set; }
        [Required]
        public double Total_cash_made { get; set; }
        [Required]
        public double Cash_paybill { get; set; }
        [Required]

        public double Cash_at_hand { get; set; }
        [Required]

        public double Expenses { get; set; }
        [Required]

        public double On_credit { get; set; }
        [Required]

        public double Availlable_cash { get; set; }

          }
}

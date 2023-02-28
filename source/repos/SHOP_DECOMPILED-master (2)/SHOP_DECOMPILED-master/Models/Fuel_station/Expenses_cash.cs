using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED.Models
{
    public class Expenses
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Expense", Prompt = "Expense")]
        public string Expense { get; set; }

        [Required]
        [Display(Name = "Ammount", Prompt = "Ammount")]
        public double Ammount { get; set; }

        [Required]
        [Display(Name = "Date", Prompt = "Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Agent_id", Prompt = "Agent_id")]
        public double Agent_id { get; set; }

        //[Required]
        //[Display(Name = "Role", Prompt = "Role")]
        //public int Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Expense
    {
        public int Id {get;set;}
        // public string Name {get;set;} = null!;
        [Required]
        public string? Description {get; set;}
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage="Amount should be positive")]
        public double Amount {get; set;}

        [Required]
        public string? Category {get; set;}
        public DateTime Date {get;set;} = DateTime.Now;
    }
}
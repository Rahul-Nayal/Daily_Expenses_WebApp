using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class FinanceAppContext:DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options){}

        public DbSet<Expense> Expenses {get; set;}

    }
}
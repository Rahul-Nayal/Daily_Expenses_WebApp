using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Data.Services
{
    public interface IExpenseServices
    {
        Task <IEnumerable<Expense>> GetAll();
        Task <Expense> GetById(int Id);
        Task Add(Expense expense);
        Task Update (Expense expense);
        Task Delete(Expense expense);
    }
    
}
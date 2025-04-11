using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Services;

namespace WebApplication1.Data.Services
{
    public class ExpensesService : IExpenseServices
    {
        private readonly FinanceAppContext _context;
        public ExpensesService(FinanceAppContext context) 
        { 
            _context = context;
        }
        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task Update(Expense expense){
                _context.Update(expense);
                await _context.SaveChangesAsync();
        }

        public async Task Delete (Expense expense){
            _context.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense> GetById(int Id){
            return await _context.Expenses.FindAsync(Id);
        }

    }
}
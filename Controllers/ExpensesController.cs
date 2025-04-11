using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Services;
namespace WebApplication1.Controllers
{
    // [Route("[controller]")]
    public class ExpensesController : Controller
    {
        // private readonly ILogger<ExpensesController> _logger;

       private readonly IExpenseServices  _expenseService;

    //    private readonly FinanceAppContext _context;

       public ExpensesController (IExpenseServices expenseService){
        _expenseService = expenseService;
        // _context = context;
       }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAll();  // here we are fetching the data from the instance of IExpenseServices
            return View(expenses);
        }
        public IActionResult Create(){
            return View();
        }

        [HttpPost]  // this method will post the data to the database
        public async Task<IActionResult> Create(Expense expense)
        {
             // ModelState is a property of Contoller Class in ASP.Net. It represents state of model binding and validation after the Http Request hits the action method.
             // it contains : - The values submitted to the server.
            if(ModelState.IsValid){
                await _expenseService.Add(expense);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update (Expense expense){
            if(ModelState.IsValid){ 
                await _expenseService.Update(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id){
            var expenses = await _expenseService.GetById(Id);
            if(expenses == null){
                return NotFound();
            }
             await _expenseService.Delete(expenses);
            return RedirectToAction("Index");
        }
    }
    
}
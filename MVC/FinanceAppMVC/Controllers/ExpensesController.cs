using FinanceAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAppMVC.Controllers
{

    public class ExpensesController : Controller
    {
        private readonly FinanceAppDbContext _context;

        public ExpensesController(FinanceAppDbContext context)
        {
            this._context= context;
        }

        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();

            return View(expenses);
        }
        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.Date = DateTime.Now;
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error","Home");
        }
    }
}

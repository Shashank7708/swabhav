using FinanceAppMVC.Models;
using FinanceAppMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;


namespace FinanceAppMVC.Controllers
{

    public class CategoryController : Controller
    {
        private readonly FinanceAppDbContext _context;
        public CategoryController(FinanceAppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCategory( int id)
        
       {
            CategroyViewModel model = new CategroyViewModel();
            model.CategoryList = await _context.Categories.ToListAsync();
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Category cat)
        {
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return Json(cat);
        }
        public async Task<IActionResult> GetById(int id)
        {
            var result=await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category cat)
        {
            _context.Categories.Update(cat);
            _context.SaveChanges();
            return Json(cat);
        }
        public async Task<IActionResult> Delele (int id)
        {
            var categroy = _context.Categories.Find(id);
            if(categroy != null)
            {
                _context.Categories.Remove(categroy);
                _context.SaveChanges();
                return Json("success");
            }
            return BadRequest("Something went wrong");

        }
    }
}

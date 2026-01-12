using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RestaurantAppMVC.Models;
using RestaurantAppMVC.Repository;

namespace RestaurantAppMVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRespository<Ingredient> _repository;

        public IngredientController(IRespository<Ingredient> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _repository.GetAllAsync();
            return View(result);
        }
        public async Task<IActionResult> GetIngredientDetials(int id)
        {
            var queryOptions = new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product" };
            var result = await _repository.GetByIdAsync(id, queryOptions);
            return View("Index1", result);

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                if (ingredient.IngredientId == 0)
                {
                    await _repository.AddAsync(ingredient);
                }
                else if (ingredient.IngredientId > 0)
                {
                    var obj = await _repository.GetByIdAsync(ingredient.IngredientId);
                    if (obj == null)
                        return BadRequest(ingredient);
                    obj.Name = ingredient.Name;
                    await _repository.UpdateAsync(obj);
                    return RedirectToAction("Index");
                }
                    return RedirectToAction("Index");
            }
            return View(ingredient);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var ingredient = await _repository.GetByIdAsync(id);
                if (ingredient == null)
                    return BadRequest("Something went wrong");
                var result=await _repository.DeleteAsync(ingredient); ;
                return RedirectToAction("Index");
            }
            return View(id);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var result=await _repository.GetByIdAsync(id);
                return View("Create", result);
            }
            return RedirectToAction("Index", "Ingredient"); ;
        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAppMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        //[Index(IsUnique = true)]
        //[StringLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://tinyurl.com/ucehtv59";
        [ValidateNever]
        public Category Category { get; set; } = null!;
        [ValidateNever]
        public ICollection<OrderItem> OrderItems { get; set; }
        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; } = new List<ProductIngredient>();
    }
}
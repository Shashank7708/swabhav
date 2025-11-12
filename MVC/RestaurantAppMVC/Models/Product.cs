using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductIngredient>? ProductIngredients { get; set; } = new List<ProductIngredient>();
    }
}
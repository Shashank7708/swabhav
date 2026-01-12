
using Microsoft.EntityFrameworkCore;
using RestaurantAppMVC.Models;
using System.Reflection.Emit;

namespace RestaurantAppMVC.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems {  get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<Product>()
            .HasIndex(u => u.Name)
            .IsUnique();

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            builder.Entity<ProductIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(x => x.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);
            builder.Entity<Category>().HasData(
                new Category { CategoryId=1,Name="Appetizer"},
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Dessert" },
                new Category { CategoryId = 5, Name = "Beverage" }
                );
            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" },
                new Ingredient { IngredientId = 2, Name = "Chicken" },
                new Ingredient { IngredientId = 3, Name = "Fish" },
                new Ingredient { IngredientId = 4, Name = "Tortilla" },
                new Ingredient { IngredientId = 5, Name = "lettuce" },
                new Ingredient { IngredientId = 6, Name = "Tomato" }

                );
            builder.Entity<Product>().HasData(
                new Product
                {
                    ProductId=1,
                    Name="Beef Taco",
                    Description="A delicious beef taco",
                    Price=2.50m,
                    Stock=100,
                    CategoryId=2,
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Chicken Taco",
                    Description = "A delicious chicken taco",
                    Price = 1.99m,
                    Stock = 100,
                    CategoryId = 2,
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Fish Taco",
                    Description = "A delicious fish taco",
                    Price = 3.99m,
                    Stock = 100,
                    CategoryId = 2,
                }
                );
            builder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId=1,IngredientId=1},
                new ProductIngredient { ProductId=1,IngredientId=4},
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 }
                );
        }

    }
}

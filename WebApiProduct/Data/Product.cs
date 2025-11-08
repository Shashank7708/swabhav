using System.ComponentModel.DataAnnotations;

namespace WebApiProduct.Repository
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }  
        public List<Order> Orders { get; set; }
    }
}

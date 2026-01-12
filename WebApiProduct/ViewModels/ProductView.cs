using System.ComponentModel.DataAnnotations;

namespace WebApiProduct.ViewModels
{
    public class ProductView
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

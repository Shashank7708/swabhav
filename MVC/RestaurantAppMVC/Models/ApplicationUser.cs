using Microsoft.AspNetCore.Identity;

namespace RestaurantAppMVC.Models
{
    public class ApplicationUser :IdentityUser
    {
        public ICollection<Order> Orders { get; set; }

    }
}

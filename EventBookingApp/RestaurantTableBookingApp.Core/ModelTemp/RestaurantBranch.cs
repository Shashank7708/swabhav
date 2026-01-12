using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantTableBookingApp.Core;

public partial class RestaurantBranch
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("ImageURL")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    
    public virtual ICollection<DiningTable> DiningTables { get; set; } = new List<DiningTable>();


   
    public virtual Restaurant? Restaurant { get; set; }
     
    
    
}

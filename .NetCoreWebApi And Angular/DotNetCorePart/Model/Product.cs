
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCorePart.Model
{
    public class Product : Audit
    {
        [Key]
        public int Id { get; set; }
        [Required,Index(IsUnique =true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; } 
        public bool IsActive { get; set; }
    }
}

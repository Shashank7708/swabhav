using System.ComponentModel.DataAnnotations;

namespace FinanceAppMVC.Models
{
    public interface IAudit
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class Category:IAudit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? MainCategory { get; set; } 
        [Range(0,int.MaxValue,ErrorMessage ="Value is invalid")]
        public int DisplayOrder { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set ; }
    }
}

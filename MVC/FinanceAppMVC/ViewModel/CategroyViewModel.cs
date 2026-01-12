using FinanceAppMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanceAppMVC.ViewModel
{
    public class CategroyViewModel
    {

        public Category Category { get; set; } = new Category();
        private List<Category> Categories = new List<Category>();
        public List<Category> CategoryList
        {
            get { return Categories; }
            set { Categories = value; }
        }
    }

}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyAspNetCore.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public List<Product>? Products { get; set; }
    }
}

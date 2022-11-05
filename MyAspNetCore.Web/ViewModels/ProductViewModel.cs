using Microsoft.Build.Framework;

namespace MyAspNetCore.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        
        [System.ComponentModel.DataAnnotations.Required( ErrorMessage = "İsim alanı boş olamaz")]
        public string? Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage="Fiyat alanı boş bırakılamaz.")]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Stok alanı boş bırakılamaz.")]
        public int? Stock { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string? Description { get; set; }
        public string? Color { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }
        public int Expire { get; set; }
    }
}

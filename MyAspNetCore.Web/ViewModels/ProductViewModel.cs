using Microsoft.Build.Framework;

namespace MyAspNetCore.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        
        [System.ComponentModel.DataAnnotations.Required( ErrorMessage = "İsim alanı boş olamaz.")]
        public string? Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage="Fiyat alanı boş olamaz.")]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Stok alanı boş olamaz.")]
        public int? Stock { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Açıklama alanı boş olamaz.")]
        public string? Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Renk seçimi boş olamaz.")]
        public string? Color { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Yayınlanma tarihi boş olamaz.")]
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Yayınlanma süresi boş olamaz.")]
        public int? Expire { get; set; }
    }
}

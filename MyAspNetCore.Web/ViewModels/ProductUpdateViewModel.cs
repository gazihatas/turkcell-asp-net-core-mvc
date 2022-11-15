using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace MyAspNetCore.Web.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [StringLength(50,ErrorMessage = "İsim alanına en fazla 50 karakter girilebilir.")]
        [System.ComponentModel.DataAnnotations.Required( ErrorMessage = "İsim alanı boş olamaz.")]
        public string? Name { get; set; }

        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})", ErrorMessage = "Fiyat alanı noktadan sonra 2 basamaklı olmalıdr.")]
        [Range(1, 1000, ErrorMessage = "Fiyat alanı 1 ile 1000 arasında bir değer olmalıdır.")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Fiyat alanı boş olamaz.")]
        public decimal? Price { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Stok alanı boş olamaz.")]
        [Range(1,200, ErrorMessage = "Stok alanı 1 ile 200 arasında bir değer olmalıdır.")]
        public int? Stock { get; set; }
        [StringLength(300,MinimumLength = 50,ErrorMessage = "Açıklama alanı 50 ile 300 karakter arasında olabilir.")]

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Açıklama alanı boş olamaz.")]
        public string? Description { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Renk seçimi boş olamaz.")]
        public string? Color { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Yayınlanma tarihi boş olamaz.")]
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Yayınlanma süresi boş olamaz.")]
        public int? Expire { get; set; }
        
        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string ImagePath { get; set; }

        //[EmailAddress(ErrorMessage = "Email adresi uygum formatta değil")]
        //public string? EmailAddress { get; set; }
    }
}

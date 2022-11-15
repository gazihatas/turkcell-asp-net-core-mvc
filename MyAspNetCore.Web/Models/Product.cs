 namespace MyAspNetCore.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        //string bir referans tiptir ve nullable alabilir.
        //.net 6 dan önce olsaydı bu ozellik  ?  eklemeden çalışacaktı
        //.net 6 da nullable olan özellik default olarak açık geldiği için 
        //bizden string de olsa ef core nullable olduğunu bellli etmek için bizden
        //? işareti bekliyor.

        public string? Color { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }
        
        public int Expire { get; set; }

        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //public string? Barcode { get; set; }
        //public int? Width { get; set; }
        //public int? Height { get; set; }
    }
}

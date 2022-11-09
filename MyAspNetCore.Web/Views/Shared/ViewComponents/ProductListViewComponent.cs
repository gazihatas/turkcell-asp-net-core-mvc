using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyAspNetCore.Web.Models;

namespace MyAspNetCore.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var viewmodels = _context.Products.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();

            if (type == 1)
            {
                return View("Default", viewmodels);
            }
            else
            {
                return View("Type2", viewmodels);
            }

            return View(viewmodels);
        }

    }
}

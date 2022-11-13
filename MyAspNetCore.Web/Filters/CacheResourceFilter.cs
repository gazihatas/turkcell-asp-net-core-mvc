using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetCore.Web.Filters
{
    public class CacheResourceFilter:Attribute,IResourceFilter
    {
        private static IActionResult _cache;

        //Request girdiği anda
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cache = context.Result;
        }

        //response üretilince çalışan metot
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (_cache!=null)
            {
                context.Result = _cache;
            }
        }
    }
}

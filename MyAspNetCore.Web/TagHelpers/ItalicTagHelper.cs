using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetCore.Web.TagHelpers
{
    public class ItalicTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //<i>Ahmet</i>
            output.PreContent.SetHtmlContent("<i>");

            output.PostContent.SetHtmlContent("</li>");
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelperSamples.Bootstrap4
{
    [HtmlTargetElement("card-footer", ParentTag = "card")]
    public class CardFooterTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var cardFooterContent = await output.GetChildContentAsync();

            var cardContext = (CardContext)context.Items[typeof(CardTagHelper)];

            var cardFooterTagBuilder = new TagBuilder("div");
            cardFooterTagBuilder.AddCssClass("card-header");
            cardFooterTagBuilder.InnerHtml.AppendHtml(cardFooterContent);

            cardContext.ChildElements.Add(cardFooterTagBuilder);

            output.SuppressOutput();
        }
    }
}

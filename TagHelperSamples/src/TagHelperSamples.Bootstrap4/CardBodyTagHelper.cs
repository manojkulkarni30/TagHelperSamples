using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelperSamples.Bootstrap4
{
    [HtmlTargetElement("card-body", ParentTag = "card")]
    public class CardBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var cardBodyContent = await output.GetChildContentAsync();

            var cardContext = (CardContext)context.Items[typeof(CardTagHelper)];

            var cardBodyTagBuilder = new TagBuilder("div");
            cardBodyTagBuilder.AddCssClass("card-body");
            cardBodyTagBuilder.InnerHtml.AppendHtml(cardBodyContent);

            cardContext.ChildElements.Add(cardBodyTagBuilder);

            output.SuppressOutput();
        }
    }
}

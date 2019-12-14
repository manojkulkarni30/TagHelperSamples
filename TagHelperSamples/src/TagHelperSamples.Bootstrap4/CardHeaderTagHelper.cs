using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelperSamples.Bootstrap4
{
    [HtmlTargetElement("card-header", ParentTag = "card")]
    public class CardHeaderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var cardHeaderContent = await output.GetChildContentAsync();

            var cardContext = (CardContext)context.Items[typeof(CardTagHelper)];

            var cardHeaderTagBuilder = new TagBuilder("div");
            cardHeaderTagBuilder.AddCssClass("card-header");
            cardHeaderTagBuilder.InnerHtml.AppendHtml(cardHeaderContent);

            cardContext.ChildElements.Add(cardHeaderTagBuilder);

            output.SuppressOutput();
        }
    }
}

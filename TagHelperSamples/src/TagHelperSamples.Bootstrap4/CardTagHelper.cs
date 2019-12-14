using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace TagHelperSamples.Bootstrap4
{
    [HtmlTargetElement("card")]
    public class CardTagHelper : TagHelper
    {
        [HtmlAttributeName("background")]
        public BackgroundColorType BackGroundType { get; set; }

        [HtmlAttributeName("border")]
        public BorderType BorderType { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var cardContext = new CardContext();

            context.Items[typeof(CardTagHelper)] = cardContext;

            await output.GetChildContentAsync();

            output.TagName = "div";

            var classBuilder = new StringBuilder();
            classBuilder.Append("card ");

            if (BackGroundType != BackgroundColorType.None)
            {
                classBuilder.Append($"bg-{BackGroundType.ToString().ToLower()} ");
                if (BackGroundType != BackgroundColorType.Light)
                {
                    classBuilder.Append("text-white");
                }
            }

            if (BorderType != BorderType.None)
            {
                classBuilder.Append($"border-{BorderType.ToString().ToLower()}");
            }

            output.Attributes.Add("class", classBuilder.ToString());

            foreach (var childElement in cardContext.ChildElements)
            {
                output.Content.AppendHtml(childElement);
            }
        }
    }
}

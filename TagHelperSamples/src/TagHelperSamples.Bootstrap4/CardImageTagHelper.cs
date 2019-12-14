using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace TagHelperSamples.Bootstrap4
{
    [HtmlTargetElement("card-img", ParentTag = "card")]
    public class CardImageTagHelper : TagHelper
    {
        [HtmlAttributeName("src")]
        public string Source { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var cardContxet = (CardContext)context.Items[typeof(CardTagHelper)];

            var imageTagBuilder = new TagBuilder("img");

            if (context.AllAttributes.Any())
            {
                foreach (var attribute in context.AllAttributes.Where(c => c.Name != "src"))
                {
                    imageTagBuilder.MergeAttribute(attribute.Name, attribute.Value.ToString());
                }
            }

            imageTagBuilder.Attributes.Add("src", Source);
            imageTagBuilder.AddCssClass("card-img-top");

            cardContxet.ChildElements.Add(imageTagBuilder);

            output.SuppressOutput();
        }
    }
}

using Microsoft.AspNetCore.Html;
using System.Collections.Generic;

namespace TagHelperSamples.Bootstrap4
{
    public class CardContext
    {
        public CardContext()
        {
            ChildElements = new List<IHtmlContent>();
        }

        public List<IHtmlContent> ChildElements { get; set; }
    }
}

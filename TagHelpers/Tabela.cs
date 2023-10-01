using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MercadoEletro.TagHelpers
{
    public class Tabela : TagHelper
    {
        public string? Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.SetAttribute("class", "table");
        }
    }
}

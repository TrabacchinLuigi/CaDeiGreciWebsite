using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CaDeiGreciWebsite.TagHelpers
{
    public class Inlinesvg : TagHelper
    {
        private static String incipit = @"<svg xmlns=""http://www.w3.org/2000/svg""";
        private readonly IWebHostEnvironment _webHostEnvironment;

        // PascalCase gets translated into kebab-case.
        public String Src { get; set; }

        public Inlinesvg(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            //output.TagMode = TagMode.SelfClosing;
            //output.Content.Clear();

            var filePath = System.IO.Path.Combine(_webHostEnvironment.WebRootPath, Src);
            using (var file = System.IO.File.OpenRead(filePath))
            using (var sr = new StreamReader(file))
            {
                var readAmount = incipit.Length;
                Span<Char> buffer = stackalloc Char[readAmount];
                var fileStart = sr.Read(buffer);
                if (!System.MemoryExtensions.Equals(buffer, incipit, StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException("The provided path is not a valid svg");

                output.Content.AppendHtml(buffer.ToString());
                foreach (var attribute in context.AllAttributes)
                {
                    if (String.Equals(attribute.Name, "src", StringComparison.OrdinalIgnoreCase)) continue;
                    output.Content.AppendHtml($@"{attribute.Name}=""{attribute.Value}""");
                }
                output.Content.AppendHtml(sr.ReadToEnd());
            }
        }
    }
}

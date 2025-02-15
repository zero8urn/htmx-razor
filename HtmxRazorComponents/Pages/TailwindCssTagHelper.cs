using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HtmxRazorComponents.Pages;

[HtmlTargetElement("tailwind-css")]
public class TailwindCssTagHelper : TagHelper
{
    private readonly IHostEnvironment _environment;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TailwindCssTagHelper(IHostEnvironment environment, IWebHostEnvironment webHostEnvironment)
    {
        _environment = environment;
        _webHostEnvironment = webHostEnvironment;
    }

    public string Include { get; set; } = "";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "link";
        output.Attributes.SetAttribute("rel", "stylesheet");

        if (_environment.IsDevelopment())
        {
            // Find the actual file that matches the pattern
            var distPath = Path.Combine(_webHostEnvironment.WebRootPath, "dist");
            var filePattern = Include.Replace("~/dist/", "").Replace("*", "*");
            var matchingFile = Directory.GetFiles(distPath, filePattern).FirstOrDefault();

            if (matchingFile != null)
            {
                var fileInfo = new FileInfo(matchingFile);
                var fileName = Path.GetFileName(matchingFile);
                var version = fileInfo.LastWriteTimeUtc.Ticks;
                output.Attributes.SetAttribute("href", $"/dist/{fileName}?v={version}");
            }
            else
            {
                output.Attributes.SetAttribute("href", Include);
            }
        }
        else
        {
            output.Attributes.SetAttribute("href", Include);
        }
    }
}

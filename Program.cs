using Blog;
using ColorCode.Common;
using ColorCode.Styling;
using Markdig;
using Markdown.ColorCode;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

StyleDictionary? sd = StyleDictionary.DefaultLight;
sd[ScopeName.PlainText].Background = "#FFF6F8FA";

builder.Services.AddScoped(sp => new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()
    .UseColorCode(sd)
    //.UseSyntaxHighlighting()
    .Build());

await builder.Build().RunAsync();

using ColorCode.Common;
using ColorCode.Styling;
using Markdig;
using Markdown.ColorCode;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Fast.Components.FluentUI;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    _ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
);

builder.Services.AddFluentUIComponents();

builder.Services.AddScoped(
    _ =>
    {
        StyleDictionary sd = StyleDictionary.DefaultLight;
        sd[ScopeName.PlainText].Background = "#FFdfe5ed";
        return new MarkdownPipelineBuilder().UseAdvancedExtensions().UseColorCode(sd).Build();
    }
);

builder.Services.AddScoped(
    sp => sp.GetService<HttpClient>()!.GetFromJsonAsync<IList<PostInfo>>("posts-info.json")
);

builder.Services.AddScoped(
    sp => sp.GetService<HttpClient>()!.GetFromJsonAsync<IList<LinkInfo>>("links-info.json")
);

await builder.Build().RunAsync();

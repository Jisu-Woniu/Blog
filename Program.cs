using ColorCode.Common;
using ColorCode.Styling;
using Markdig;
using Markdown.ColorCode;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Fast.Components.FluentUI;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();
builder.Services.AddHttpClient(
    "Local",
    httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    }
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
    sp =>
    {
        HttpClient client = sp.GetService<IHttpClientFactory>()!.CreateClient("Local");

        return client.GetFromJsonAsync<IList<PostInfo>>("posts-info.json");
    }
);

builder.Services.AddScoped(
    sp =>
    {
        HttpClient client = sp.GetService<IHttpClientFactory>()!.CreateClient("Local");
        return client.GetFromJsonAsync<IList<LinkInfo>>("links-info.json");
    }
);

if (builder.HostEnvironment.IsProduction())
{
    builder.Logging.SetMinimumLevel(LogLevel.Warning);
}

await builder.Build().RunAsync();

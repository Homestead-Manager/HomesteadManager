using HomesteadManagerUi;
using HomesteadManagerUi.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var configuration = builder.Configuration.Build();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(configuration["ApiBaseUrl"])
});
builder.Services.AddScoped<ApiService>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();

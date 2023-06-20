global using ContactsCRUD.Client.Services.ContactsService;
global using ContactsCRUD.Shared;
using ContactsCRUD.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IContactService , ContactService>(); // Rejestracja ContactsServices 

await builder.Build().RunAsync();

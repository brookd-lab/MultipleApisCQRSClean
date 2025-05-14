using ConsumeEmployeeApiMvcClean.Domain.Interfaces;
using ConsumeEmployeeApiMvcClean.Infrastructure.ApiClients;
using Microsoft.Extensions.FileProviders;

Consumer.Get();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IEmployeeApiClient,EmployeeApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7224"); // Change to your API base URL
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Employees/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

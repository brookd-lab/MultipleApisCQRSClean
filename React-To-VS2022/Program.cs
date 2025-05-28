using Microsoft.EntityFrameworkCore; // Ensure this directive is present to include EF Core extensions.
using React_To_VS2022.Data; // Ensure this directive is present to resolve the 'UseInMemoryDatabase' method.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CardsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();

app.Run();

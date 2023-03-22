using Plant.NET;
using Plant.NET.Infrastructure;
using BotaniFinder.Models;
using BotaniFinder.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Configure services method
 void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    string connectionString = builder.Configuration.GetConnectionString("BotaniFinderDbContext");
    services.AddDbContext<BotaniFinderDbContext>(options => options.UseSqlServer(connectionString));

    services.AddPlantNetClient(options => options.ApiKey = "2b10JXYocEFbfuM3nMDtQa93e");
}

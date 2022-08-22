using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ServiceRepositoryPattern.Data;
using ServiceRepositoryPattern.Services;
using ServiceRepositoryPattern.Repository;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging.File;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ServiceRepositoryPatternContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceRepositoryPatternContext") ?? throw new InvalidOperationException("Connection string 'StudentContext' not found.")));

builder.Services.AddTransient<IFoodService, FoodService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddSingleton<IFoodRepository, FoodRepository>();
builder.Services.AddSingleton<ITicketRepository, TicketRepository>();

//Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var loggerfactory = app.Services.GetRequiredService<ILoggerFactory>();
var path = Directory.GetCurrentDirectory();
loggerfactory.AddFile($"{path}\\Logs\\Log.txt");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FoodItems}/{action=Index}/{id?}");

app.Run();

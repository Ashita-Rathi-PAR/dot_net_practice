using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ServiceRepositoryPattern.Data;
using ServiceRepositoryPattern.Services;
using ServiceRepositoryPattern.Repository;

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//namespace ServiceRepositoryPattern
//{
//    class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);
//            builder.Services.AddDbContext<ServiceRepositoryPatternContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceRepositoryPatternContext") ?? throw new InvalidOperationException("Connection string 'StudentContext' not found.")));

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();
//            var app = builder.Build();

//            var services = new ServiceCollection();
//            ConfigureServices(services);

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.Run();

//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddSingleton<IFoodService, FoodService>();
//            services.AddSingleton<ITicketService, TicketService>();
//        }
//    }
//}
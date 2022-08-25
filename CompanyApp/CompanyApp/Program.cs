using Microsoft.EntityFrameworkCore;
using CompanyApp.Data;
using CompanyApp.Service;
using CompanyApp.Repository;
using CompanyApp.Exception;
using Serilog.Extensions.Logging.File;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContext") ?? throw new InvalidOperationException("Connection string 'EmployeeContext' not found.")));

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddMvc(options => options.Filters.Add(new HandleExceptionAttribute()));

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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();

using EmployeeData;
using EmployeeManagement;
using EmployeeService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EmplyeeDbContext>();
builder.Services.AddScoped<IEmployeeService,EmployeeDataService>();
builder.Services.AddScoped<IEmployeeDetailFactory, EmployeeDetailFactory>();

//Ms Sql Db Connection
string  ConnString  = builder.Configuration.GetConnectionString("connMSSQL");
builder.Services.AddDbContext<EmplyeeDbContext>(options => options.UseSqlServer(ConnString));
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

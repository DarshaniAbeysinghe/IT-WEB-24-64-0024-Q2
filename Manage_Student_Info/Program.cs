using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Manage_Student_Info.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Manage_Student_InfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Manage_Student_InfoContext") ?? throw new InvalidOperationException("Connection string 'Manage_Student_InfoContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Configure endpoint routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route for MVC
    endpoints.MapRazorPages(); // Map Razor Pages
});
app.Run();

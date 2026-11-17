using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StyleStore.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StyleStoreIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'StyleStoreIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<StyleStoreIdentityDbContext>(
    options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<StyleStoreIdentityDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();



builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");



//redundant 

// app.MapControllerRoute(
//     name: "Admin Home Page",
//     pattern: "{controller=Admin}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();







app.Run();

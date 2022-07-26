using Microsoft.EntityFrameworkCore;
using TpCRUDMVCScolariteSuivi.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ScolariteDbEntities>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("maChaineDeConnexion")
    ));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ScolariteDbEntities>();


builder.Services.AddAuthentication()
    .AddGoogle(optsGoogle => {
        optsGoogle.ClientId = "rajout de l'id admin";
        optsGoogle.ClientSecret = "clef secrete de l'admin";
    });



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppTp2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Ajouter le services d'acc�s � la base
builder.Services.AddDbContext<VoitureDbEntities>( opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("maChaineDeConnexion")
    ));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<VoitureDbEntities>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<VoitureDbEntities>();
// Ajout du service d'authentification
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<VoitureDbEntities>();

builder.Services.AddAuthentication()
    .AddGoogle(optsGoogle =>{
        optsGoogle.ClientId = "1003527487727-gk3k60rps1vni6tjsr8i7rohfptio9u0.apps.googleusercontent.com";
        optsGoogle.ClientSecret = "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";
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

// Ajouter le middelware d'authentification
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();  // Pour les pages d'authentification de login
app.Run();

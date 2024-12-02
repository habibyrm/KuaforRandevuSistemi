using Microsoft.EntityFrameworkCore;
using webdeneme.Models; // KuaforDbContext'i tan�tt���n�z namespace

var builder = WebApplication.CreateBuilder(args);

// Session i�in gerekli hizmetleri ekleyin
builder.Services.AddDistributedMemoryCache(); // Bellekte oturumlar� saklamak i�in
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman a��m� s�resi
    options.Cookie.HttpOnly = true; // G�venlik amac�yla
    options.Cookie.IsEssential = true; // �erezlerin gerekli oldu�unu belirtir
});
// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritaban� ba�lam�n� ekleyin
builder.Services.AddDbContext<KuaforDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ba�lant� dizesini kullan

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

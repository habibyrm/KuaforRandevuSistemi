using Microsoft.EntityFrameworkCore;
using webdeneme.Models; // KuaforDbContext'i tanýttýðýnýz namespace

var builder = WebApplication.CreateBuilder(args);

// Session için gerekli hizmetleri ekleyin
builder.Services.AddDistributedMemoryCache(); // Bellekte oturumlarý saklamak için
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmý süresi
    options.Cookie.HttpOnly = true; // Güvenlik amacýyla
    options.Cookie.IsEssential = true; // Çerezlerin gerekli olduðunu belirtir
});
// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabaný baðlamýný ekleyin
builder.Services.AddDbContext<KuaforDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Baðlantý dizesini kullan

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

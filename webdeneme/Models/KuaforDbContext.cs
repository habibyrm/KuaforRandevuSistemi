using Microsoft.EntityFrameworkCore;

namespace webdeneme.Models
{
    public class KuaforDbContext : DbContext
    {
        public KuaforDbContext(DbContextOptions<KuaforDbContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<AdminRapor> AdminRaporlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Islem>()
                .Property(i => i.Ucret)
                .HasColumnType("decimal(18,2)"); // Hassasiyet ayarlandı
        }
    }
}

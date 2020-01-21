using Microsoft.EntityFrameworkCore;
using ProjeYonetim.Models;

namespace ProjeYonetim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Altrapor> AltRaporlar { get; set; }
        public DbSet<Modul> Modul { get; set; }
        public DbSet<Proje> Proje { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
    }
}
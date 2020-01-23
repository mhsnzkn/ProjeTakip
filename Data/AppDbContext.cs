using Microsoft.EntityFrameworkCore;
using ProjeYonetim.Models;

namespace ProjeYonetim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Modul> Moduller { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<RaporTur> RaporTurleri { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
    }
}
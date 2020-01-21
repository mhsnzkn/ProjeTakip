using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class Altrapor
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public int ModulId { get; set; }
        public int RaporId { get; set; }
        [StringLength(100)]
        public string Adi { get; set; }
        public int Sira { get; set; }
        [StringLength(300)]
        public string Link { get; set; }
        public virtual Proje Proje { get; set; }
        public virtual Modul Modul { get; set; }
        public virtual Rapor Rapor { get; set; }

    }
}
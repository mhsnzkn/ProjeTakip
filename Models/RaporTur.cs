using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class RaporTur
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public int ModulId { get; set; }
        [StringLength(100)]
        public string Adi { get; set; }
        public int Sira { get; set; }
        [StringLength(400)]
        public string Aciklama { get; set; }
        public bool Active { get; set; }
        public virtual Proje Proje { get; set; }
        public virtual Modul Modul { get; set; }

    }
}
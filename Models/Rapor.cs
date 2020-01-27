using System;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class Rapor
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public int ModulId { get; set; }
        public int RaporTurId { get; set; }
        [StringLength(100)]
        public string Adi { get; set; }
        public int Sira { get; set; }
        [StringLength(300)]
        public string Aciklama { get; set; }
        public bool Active { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime CrtDate { get; set; }
        public virtual Proje Proje { get; set; }
        public virtual Modul Modul { get; set; }
        public virtual RaporTur RaporTur { get; set; }

    }
}
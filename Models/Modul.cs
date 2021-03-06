using System;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class Modul
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        [StringLength(100)]
        public string Adi { get; set; }
        public int Sira { get; set; }
        [StringLength(100)]
        public string Fontawesome { get; set; }
        [StringLength(150)]
        public string DemoLink { get; set; }
        public bool Active { get; set; }
        public DateTime CrtDate { get; set; }
        public DateTime? UptDate { get; set; }
        public virtual Proje Proje { get; set; }
    }
}
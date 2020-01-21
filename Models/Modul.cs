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
        public virtual Proje Proje { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class Proje
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        public int Sira { get; set; }
        public bool Active { get; set; }
        public DateTime CrtDate { get; set; }
        public DateTime? UptDate { get; set; }
    }
}
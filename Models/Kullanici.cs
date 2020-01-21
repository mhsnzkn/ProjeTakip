using System.ComponentModel.DataAnnotations;

namespace ProjeYonetim.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
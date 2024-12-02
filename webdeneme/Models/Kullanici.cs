using System.ComponentModel.DataAnnotations;

namespace webdeneme.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar (Primary Key)

        [Required]
        [StringLength(100)]
        public string AdSoyad { get; set; } // Kullanıcının tam adı

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Kullanıcının e-posta adresi

        [Required]
        public string Sifre { get; set; } // Kullanıcının şifresi (hashlenmiş)

        public bool AdminMi { get; set; } = false; // Kullanıcının admin olup olmadığını belirtir
    }

}

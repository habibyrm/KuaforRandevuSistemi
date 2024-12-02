using System.ComponentModel.DataAnnotations;

namespace webdeneme.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        [Required]
        [StringLength(100)]
        public string AdSoyad { get; set; } // Çalışanın tam adı

        [Required]
        public string Beceriler { get; set; } // Çalışanın uzman olduğu hizmetler (örneğin: "Saç Kesimi, Boyama")

        public bool MusaitMi { get; set; } = true; // Uzmanın müsait olup olmadığını belirtir
    }
}

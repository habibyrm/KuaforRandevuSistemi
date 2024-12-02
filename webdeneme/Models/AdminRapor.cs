using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webdeneme.Models
{
    public class AdminRapor
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        [Required]
        public DateTime Tarih { get; set; } // Raporun tarihi

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ToplamGelir { get; set; } // Belirtilen tarihte elde edilen toplam gelir

        public int ToplamRandevuSayisi { get; set; } // Toplam gerçekleştirilen randevular
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webdeneme.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        [Required]
        [ForeignKey("Musteri")]
        public int MusteriId { get; set; } // Randevuyu oluşturan müşteri

        public Kullanici Musteri { get; set; } // İlişkili müşteri

        [Required]
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; } // Randevuyu gerçekleştirecek uzman

        public Calisan Calisan { get; set; } // İlişkili çalışan

        [Required]
        [ForeignKey("Islem")]
        public int IslemId { get; set; } // Randevudaki hizmet

        public Islem Islem { get; set; } // İlişkili hizmet

        [Required]
        public DateTime RandevuTarihi { get; set; } // Randevu tarihi ve saati

        [Required]
        public string Durum { get; set; } = "Beklemede"; // Randevu durumu (örneğin: "Beklemede", "Tamamlandı")
    }
}

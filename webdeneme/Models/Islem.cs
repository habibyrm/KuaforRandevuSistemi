using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webdeneme.Models
{
    public class Islem
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        [Required]
        [StringLength(100)]
        public string Ad { get; set; } // Hizmetin adı (örneğin: "Saç Kesimi")

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ucret { get; set; } // Hizmetin ücreti

        [Required]
        public int Sure { get; set; } // Hizmetin süresi (dakika cinsinden)
    }

}

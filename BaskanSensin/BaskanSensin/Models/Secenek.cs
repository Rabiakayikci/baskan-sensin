using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaskanSensin.Models
{
    public class Secenek
    {
        [Key]
        public int Secenekid { get; set; }

        [Required]
        [Display(Name = "Seçenek Metni")]
        public string Metin { get; set; }

        
        public int Soruid { get; set; } 

        [ForeignKey("Soruid")]
        public virtual Soru Soru { get; set; } 

        public int? Yetid { get; set; } 

        [ForeignKey("Yetid")]
        [Display(Name = "İlgili Yetenek")]
        public virtual Yetenek Yetenek { get; set; }
    }
}

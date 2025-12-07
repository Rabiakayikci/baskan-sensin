using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaskanSensin.Models
{
    public class Skor
    {

        [Key]
        public int Skorid { get; set; }

        public Guid Cocukid { get; set; }

        [ForeignKey("Cocukid")]
        public virtual User Cocuk { get; set; }



        [Display(Name = "Analitik Puanı")]
        public int Analitikp { get; set; }

        [Display(Name = "Sanat Puanı")]
        public int Sanatp { get; set; }

        [Display(Name = "Doğa Puanı")]
        public int Dogap { get; set; }

        [Display(Name = "Sosyal Puanı")]
        public int Sosyalp { get; set; }

        [Display(Name = "Spor Puanı")]
        public int Sporp { get; set; }

        [Display(Name = "Baskın Yetenek")]
        [StringLength(50)]
        public string Baskinyet { get; set; }
    }
}

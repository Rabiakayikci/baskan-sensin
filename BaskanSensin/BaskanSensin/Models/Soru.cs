using System.ComponentModel.DataAnnotations;

namespace BaskanSensin.Models
{
    public class Soru
    {
        [Key]
        public int Soruid { get; set; }

        [Required]
        [Display(Name = "Soru Metni")]
        public string Metin { get; set; }
        public virtual ICollection<Secenek> Secenekler { get; set; }
    }
}

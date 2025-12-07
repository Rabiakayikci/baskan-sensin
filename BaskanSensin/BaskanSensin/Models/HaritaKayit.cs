using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaskanSensin.Models
{
    public class HaritaKayit
    {
        [Key]
        public int Haritaid { get; set; }
        public Guid Cocukid { get; set; }

        [ForeignKey("Cocukid")]
        public virtual User Cocuk { get; set; }

        
        public int Yapiid { get; set; }

        [ForeignKey("Yapiid")]
        public virtual Yapi Yapi { get; set; }


        [Display(Name = "Bölüm")]
        public int Slotno { get; set; } 

        [Display(Name = "Kalan Süre (Dk)")]
        public int Beklemesuresi { get; set; } 

        [Display(Name = "Tamamlandı mı?")]
        public bool Tamamlanmadurumu { get; set; }
    }
}

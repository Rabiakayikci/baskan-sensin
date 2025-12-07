using System.ComponentModel.DataAnnotations;

namespace BaskanSensin.Models
{
    public class Yapi
    {

        [Key]
        public int Yapid { get; set; }

        [Display(Name = "Bina Adı")]
        public string Binaad { get; set; }

        [Display(Name = "Bilgi Kartı")]
        [DataType(DataType.MultilineText)]
        public string BilgiKarti { get; set; }

        public string Resim { get; set; }

        [Display(Name = "Bekleme Süresi (Dk)")]
        public int Beklemesuresi { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace BaskanSensin.Models
{
    public class Yetenek
    {
        
            [Key]
            public int Yetid { get; set; }
        [Display(Name = "Yetenek Adı")]
            public string Yetad { get; set; }

        }
    
}

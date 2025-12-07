using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaskanSensin.Models
{
    public enum KRol
    {
        Admin = 1,
        Veli = 2,
        Cocuk = 3,
    }
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        [StringLength(30)]
        public string KullaniciAdi { get; set; }

 
        [Required(ErrorMessage = "Şifre girmelisiniz.")]
        public string Sifre { get; set; }

       
        [Required]
        [StringLength(60)]
        public string AdSoyad { get; set; }

        
        public string Adres { get; set; }

      
        public Guid? VeliId { get; set; }

       
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

       
        [Required]
        public KRol Rol { get; set; }

        [ForeignKey("VeliId")] 
        public virtual User? Veli { get; set; }

    }
}

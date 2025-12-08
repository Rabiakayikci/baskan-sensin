namespace BaskanSensin.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public string Rol { get; set; }
        public Guid? VeliId { get; set; }

        public string Adres { get; set; }
    }
}

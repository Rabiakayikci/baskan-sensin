using BaskanSensin.Dtos;
using BaskanSensin.Models;

namespace BaskanSensin.Services
{
    public interface IHesapYonetimService
    {

       Task<User> VeliKayitAsync(RegisterDto dto);
       Task<User> GirisAsync(LoginDto dto);
       Task<User> CocukEkleAsync(Guid veliId, CocukEkleDto dto);

        Task SifreDegistirAsync(Guid userId, string eskiSifre, string yeniSifre);
        Task KullaniciAdiDegistirAsync(Guid userId, string yeniKullaniciAdi);
        Task AdresDegistirAsync(Guid userId, string yeniAdres);
        Task<List<User>> GetCocuklarByVeliIdAsync(Guid veliId);
        Task<Skor> GetSkorByCocukIdAsync(Guid cocukId);

        Task PuanVerAsync(Guid cocukId, string secim);
        
        Task<Soru> GetSoruWithSeceneklerAsync(int soruId);

        Task<Dictionary<string, int>> GetCocukSkorlariAsync(Guid cocukId);

    }
}

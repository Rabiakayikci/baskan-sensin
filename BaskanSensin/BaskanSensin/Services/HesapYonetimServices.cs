using BaskanSensin.Data;
using BaskanSensin.Dtos;
using BaskanSensin.Models;
using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration;

namespace BaskanSensin.Services
{
    public class HesapYonetimServices : IHesapYonetimService
    {

        private readonly ApplicationDbContext _db; 
        private readonly IConfiguration _cfg;      
        private readonly PasswordHasher<User> _hasher;

        public HesapYonetimServices(ApplicationDbContext db, IConfiguration cfg)
        {
            _db = db;
            _cfg = cfg;
            _hasher = new PasswordHasher<User>();
        }

        public async Task<User> VeliKayitAsync(RegisterDto dto)
        {
            
            if (await _db.Users.AnyAsync(u => u.KullaniciAdi == dto.KullaniciAdi))
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");

            
            var user = new User
            {
                UserId = Guid.NewGuid(),
                KullaniciAdi = dto.KullaniciAdi,
                AdSoyad = dto.AdSoyad,
                Rol = KRol.Veli,
                Adres = dto.Adres,
                DogumTarihi = new DateTime(2000,1,1)
               
            };

            user.Sifre = _hasher.HashPassword(user, dto.Sifre);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;

        }



        public async Task<User> GirisAsync(LoginDto dto)
        {
        
            var user = await _db.Users.FirstOrDefaultAsync(u => u.KullaniciAdi == dto.KullaniciAdi);

            if (user == null) throw new Exception("Kullanıcı bulunamadı.");

        
            var sifredogrulama = _hasher.VerifyHashedPassword(user, user.Sifre, dto.Sifre);
            if (sifredogrulama == PasswordVerificationResult.Failed) throw new Exception("Şifre hatalı.");

            user.Veli = null;

         
            return user;
        }



        public async Task<User> CocukEkleAsync(Guid veliId, CocukEkleDto dto)
        {
            
            var veli = await _db.Users.FindAsync(veliId);
            if (veli == null) throw new Exception("Veli bulunamadı, çocuk eklenemez.");

            
            if (await _db.Users.AnyAsync(u => u.KullaniciAdi == dto.KullaniciAdi))
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");

            
            var cocuk = new User
            {
                UserId = Guid.NewGuid(),

                KullaniciAdi = dto.KullaniciAdi,
                AdSoyad = dto.AdSoyad,
                DogumTarihi = dto.DogumTarihi,

                Rol = KRol.Cocuk,
                VeliId = veliId,

                
                Adres = "Ebeveyn Yanı", 
            };

            cocuk.Sifre = _hasher.HashPassword(cocuk, dto.Sifre);

            _db.Users.Add(cocuk);
            await _db.SaveChangesAsync();

            return cocuk;
        }
        

        public async Task SifreDegistirAsync(Guid userId, string eskiSifre, string yeniSifre)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) throw new Exception("Kullanıcı bulunamadı.");

           
            var dogrulama = _hasher.VerifyHashedPassword(user, user.Sifre, eskiSifre);
            if (dogrulama == PasswordVerificationResult.Failed)
                throw new Exception("Mevcut şifreniz hatalı.");

            
            user.Sifre = _hasher.HashPassword(user, yeniSifre);
            await _db.SaveChangesAsync();
        }

        public async Task KullaniciAdiDegistirAsync(Guid userId, string yeniKullaniciAdi)
        {
            
            if (await _db.Users.AnyAsync(u => u.KullaniciAdi == yeniKullaniciAdi))
                throw new Exception("Bu kullanıcı adı zaten kullanımda.");

            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.KullaniciAdi = yeniKullaniciAdi;
                await _db.SaveChangesAsync();
            }
        }

        public async Task AdresDegistirAsync(Guid userId, string yeniAdres)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.Adres = yeniAdres;
                await _db.SaveChangesAsync();
            }
        }

       
        public async Task<List<User>> GetCocuklarByVeliIdAsync(Guid veliId)
        {
            
            return await _db.Users
                            .Where(u => u.VeliId == veliId && u.Rol == KRol.Cocuk)
                            .ToListAsync();
        }


        public async Task<Skor> GetSkorByCocukIdAsync(Guid cocukId)
        {
            
            return await _db.Skorlar.FirstOrDefaultAsync(s => s.Cocukid == cocukId);
        }


        public async Task PuanVerAsync(Guid cocukId, string secim)
        {
            
            var skor = await _db.Skorlar.FirstOrDefaultAsync(s => s.Cocukid == cocukId);

            
            if (skor == null)
            {
                skor = new Skor
                {
                    Cocukid = cocukId,
                    Analitikp = 0,
                    Sanatp = 0,
                    Dogap = 0,
                    Sosyalp = 0,
                    Sporp = 0,
                    Baskinyet = "Henüz Belirsiz"
                };
                _db.Skorlar.Add(skor);
            }

         
            switch (secim.ToUpper())
            {
                case "A": skor.Analitikp++; break;
                case "B": skor.Sanatp++; break;
                case "C": skor.Dogap++; break; 
                case "D": skor.Sosyalp++; break; 
                case "E": skor.Sporp++; break;
                  
            }

           
            int maxPuan = skor.Analitikp;
            string baskin = "Analitik Zeka (Mühendis)";

            if (skor.Sanatp > maxPuan) { maxPuan = skor.Sanatp; baskin = "Sanatsal Zeka (Tasarımcı)"; }
            if (skor.Dogap > maxPuan) { maxPuan = skor.Dogap; baskin = "Doğa Zekası (Biyolog)"; }
            if (skor.Sosyalp > maxPuan) { maxPuan = skor.Sosyalp; baskin = "Sosyal Zeka (Lider)"; }
            if (skor.Sporp > maxPuan) { maxPuan = skor.Sporp; baskin = "Bedensel Zeka (Sporcu)"; }

            
            if (maxPuan == 0) baskin = "Henüz Belirsiz";

            skor.Baskinyet = baskin;

            
            await _db.SaveChangesAsync();
        }

        
        public async Task<Soru> GetSoruWithSeceneklerAsync(int soruId)
        {
            
            var soru = await _db.Sorular
                                .Include(s => s.Secenekler) 
                                .FirstOrDefaultAsync(s => s.Soruid == soruId);
            return soru;
        }



        
        public async Task<Dictionary<string, int>> GetCocukSkorlariAsync(Guid cocukId)
        {
            
            var skorlar = await _db.Skorlar
                                   .AsNoTracking() 
                                   .FirstOrDefaultAsync(s => s.Cocukid == cocukId);

           
            if (skorlar == null)
            {
                return new Dictionary<string, int>
        {
            {"analitik", 0},
            {"sanat", 0},
            {"doga", 0},
            {"sosyal", 0},
            {"spor", 0}
        };
            }

         
            return new Dictionary<string, int>
    {
        {"analitik", skorlar.Analitikp},
        {"sanat", skorlar.Sanatp},
        {"doga", skorlar.Dogap},
        {"sosyal", skorlar.Sosyalp},
        {"spor", skorlar.Sporp}
    };
        }


    }




}

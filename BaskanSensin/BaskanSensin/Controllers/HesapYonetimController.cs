using BaskanSensin.Dtos;
using BaskanSensin.Models;
using BaskanSensin.Services; 
using Microsoft.AspNetCore.Mvc;

namespace BaskanSensin.Controllers
{
    public class HesapYonetimController : Controller
    {
      
        private readonly IHesapYonetimService _service;
        private readonly OpenAIService _aiService;

        public HesapYonetimController(IHesapYonetimService service, OpenAIService aiService)
        {
            _service = service;
            _aiService = aiService;
        }
       

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(LoginDto dto)
        {
                var user = await _service.GirisAsync(dto);
                if (user.Rol == KRol.Veli)
                {
                    return RedirectToAction("VeliAnasayfa", "HesapYonetim", new { id = user.UserId });
                }
                else if (user.Rol == KRol.Cocuk)
                {
                    return RedirectToAction("Harita", "Oyun", new { cocukId = user.UserId });
                }
                else if (user.Rol == KRol.Admin)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");

            


        }

        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(RegisterDto dto)
        {
            try
            {
                await _service.VeliKayitAsync(dto);
                TempData["Basari"] = "Kayıt başarılı! Lütfen giriş yapın.";
                return RedirectToAction("Giris");
            }
            catch (Exception ex)
            {
                TempData["Hata"] = ex.Message;
                return View("Kayit");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VeliAnasayfa(Guid? id)
        {
            if (id == null) return RedirectToAction("Giris");
            var cocuklar = await _service.GetCocuklarByVeliIdAsync(id.Value);
            ViewBag.VeliId = id;
            return View(cocuklar);
        }

        [HttpGet]
        public IActionResult CocukEkle(Guid veliId)
        {
            ViewBag.VeliId = veliId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CocukEkle(Guid veliId, CocukEkleDto dto)
        {
            try
            {
                await _service.CocukEkleAsync(veliId, dto);
                TempData["Basari"] = "Çocuk başarıyla eklendi.";
                return RedirectToAction("VeliAnasayfa", new { id = veliId });
            }
            catch (Exception ex)
            {
                TempData["Hata"] = ex.Message;
                ViewBag.VeliId = veliId;
                return View(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SifreGuncelle(Guid userId, string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {
            try
            {
                if (yeniSifre != yeniSifreTekrar) throw new Exception("Yeni şifreler uyuşmuyor.");
                await _service.SifreDegistirAsync(userId, eskiSifre, yeniSifre);
                TempData["Basari"] = "Şifreniz başarıyla değiştirildi.";
            }
            catch (Exception ex) { TempData["Hata"] = ex.Message; }
            return RedirectToAction("VeliAnasayfa", new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciAdiGuncelle(Guid userId, string yeniKullaniciAdi)
        {
            try
            {
                await _service.KullaniciAdiDegistirAsync(userId, yeniKullaniciAdi);
                TempData["Basari"] = "Kullanıcı adı güncellendi.";
            }
            catch (Exception ex) { TempData["Hata"] = ex.Message; }
            return RedirectToAction("VeliAnasayfa", new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> AdresGuncelle(Guid userId, string yeniAdres)
        {
            try
            {
                await _service.AdresDegistirAsync(userId, yeniAdres);
                TempData["Basari"] = "Adres bilgisi güncellendi.";
            }
            catch (Exception ex) { TempData["Hata"] = ex.Message; }
            return RedirectToAction("VeliAnasayfa", new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> CocukSifreGuncelle(Guid cocukId, string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {
            try
            {
                if (yeniSifre != yeniSifreTekrar) throw new Exception("Yeni şifreler uyuşmuyor.");
                await _service.SifreDegistirAsync(cocukId, eskiSifre, yeniSifre);
                TempData["Basari"] = "Çocuğun şifresi başarıyla değiştirildi.";
            }
            catch (Exception ex) { TempData["Hata"] = ex.Message; }
            return RedirectToAction("Rapor", new { cocukId = cocukId });
        }

        [HttpPost]
        public async Task<IActionResult> CocukKullaniciAdiGuncelle(Guid cocukId, string yeniKullaniciAdi)
        {
            try
            {
                await _service.KullaniciAdiDegistirAsync(cocukId, yeniKullaniciAdi);
                TempData["Basari"] = "Çocuğun kullanıcı adı güncellendi.";
            }
            catch (Exception ex) { TempData["Hata"] = ex.Message; }
            return RedirectToAction("Rapor", new { cocukId = cocukId });
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Rapor(Guid cocukId)
        {
            ViewBag.CocukId = cocukId;
            ViewBag.CocukAd = "Öğrenci";

            
            var skorlar = await _service.GetCocukSkorlariAsync(cocukId);

           
            var analitik = skorlar["analitik"];
            var sanat = skorlar["sanat"];
            var doga = skorlar["doga"];
            var sosyal = skorlar["sosyal"];
            var spor = skorlar["spor"];

            string aiRaporu = "Yapay zeka servisi şu an devre dışı.";
            try
            {
                
                aiRaporu = await _aiService.RaporOlustur(analitik, sanat, doga, sosyal, spor);
            }
            catch
            {
                aiRaporu = "Bağlantı hatası: Yapay zeka raporu oluşturulamadı.";
            }

            ViewBag.AiRaporu = aiRaporu;

            
            ViewBag.Skorlar = new { analitik, sanat, doga, sosyal, spor };

            return View();
        }
    }
}
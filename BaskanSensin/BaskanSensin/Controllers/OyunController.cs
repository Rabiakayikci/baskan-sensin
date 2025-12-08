using BaskanSensin.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaskanSensin.Controllers
{
    public class OyunController : Controller
    {
        private readonly IHesapYonetimService _service;

        public OyunController(IHesapYonetimService service)
        {
            _service = service;
        }

       
        [HttpGet]
        public async Task<IActionResult> Harita(Guid cocukId)
        {
            ViewBag.CocukId = cocukId;
            var skor = await _service.GetSkorByCocukIdAsync(cocukId);
            int completedLevel = 0;
            if (skor != null)
            {
                int total = skor.Analitikp + skor.Sanatp + skor.Dogap + skor.Sosyalp + skor.Sporp;
                // Assuming 6 questions corresponds to finishing Level 1
                if (total >= 6)
                {
                    completedLevel = 1;
                }
            }
            ViewBag.CompletedLevel = completedLevel;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Oyna(Guid cocukId, int soruNo = 1)
        {
            // Limit to 6 questions.
            if (soruNo > 6)
            {
                // cocukId is needed for the map
                // levelCompleted=1 tells the map to look for "1" in local storage logic or just triggers the success bubble
                return RedirectToAction("Harita", "Oyun", new { cocukId = cocukId, levelCompleted = 1 });
            }

            var soru = await _service.GetSoruWithSeceneklerAsync(soruNo);

            // Fallback if question not found
            if (soru == null)
            {
                return RedirectToAction("Harita", "Oyun", new { cocukId = cocukId, levelCompleted = 1 });
            }

            ViewBag.CocukId = cocukId;
            ViewBag.SoruNo = soruNo;
           
            return View(soru);
        }
        public async Task<IActionResult> PuanEkle(Guid cocukId, string tur, int suankiSoruNo)
        {
            
            await _service.PuanVerAsync(cocukId, tur);

            
            return RedirectToAction("Oyna", new { cocukId = cocukId, soruNo = suankiSoruNo + 1 });
        }
    }
}
using System.Text;
using System.Text.Json;

namespace BaskanSensin.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "BURAYA_SK_ILE_BASLAYAN_API_KEYINI_YAZ"; 
        public OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RaporOlustur(int analitik, int sanat, int doga, int sosyal, int spor)
        {
           
            var prompt = $@"
                Sen uzman bir pedagog ve kariyer danışmanısın. 
                6-14 yaş aralığındaki bir çocuğun 'Başkan Sensin' oyunundaki yetenek skorları aşağıdadır:
                
                - Analitik Zeka (Mühendislik): {analitik}/100
                - Sanat Zekası: {sanat}/100
                - Doğa Zekası: {doga}/100
                - Sosyal Zeka: {sosyal}/100
                - Spor/Bedensel: {spor}/100

                Lütfen bu skorlara göre çocuğun ebeveynine hitaben samimi ve profesyonel bir rapor yaz.
                1. Çocuğun en baskın yeteneğini vurgula.
                2. Geliştirilmesi gereken yönleri için tavsiye ver.
                3. Yerel Belediyenin şu kurslarından hangilerine gitmesi gerektiğini öner: (Robotik Kodlama, Yüzme, Resim Atölyesi, İzcilik Kampı, Drama, Satranç).
                
                Cevabı HTML formatında değil, sadece düz yazı paragrafları olarak ver.";

           
            // If API key is the default placeholder, use the simulated Free AI logic.
            if (_apiKey.StartsWith("BURAYA_SK"))
            {
                return SimulateAIReport(analitik, sanat, doga, sosyal, spor);
            }

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen yardımsever bir eğitim asistanısın." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

           
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            try 
            {
                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonDocument.Parse(responseString);
                    return responseJson.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                }
            }
            catch {}

            // Fallback to simulation if API fails
            return SimulateAIReport(analitik, sanat, doga, sosyal, spor);
        }

        private string SimulateAIReport(int analitik, int sanat, int doga, int sosyal, int spor)
        {
            // Determine dominant trait
            var scores = new Dictionary<string, int> {
                { "Analitik Zeka (Mühendis)", analitik },
                { "Sanat Zekası (Tasarımcı)", sanat },
                { "Doğa Zekası (Biyolog)", doga },
                { "Sosyal Zeka (Lider)", sosyal },
                { "Bedensel Zeka (Sporcu)", spor }
            };

            var dominant = scores.OrderByDescending(x => x.Value).First();
            string trait = dominant.Key;

            string paragraph1 = "";
            string recommendation = "";

            if (trait.Contains("Analitik"))
            {
                paragraph1 = "Çocuğunuzda güçlü bir <strong>Analitik Zeka</strong> potansiyeli gözlemlenmiştir. Problem çözme becerileri, mantıksal kurgulaması ve neden-sonuç ilişkisi kurma yeteneği yaşıtlarına göre oldukça ileride. Sayısal verilere ve mekanik sistemlere olan ilgisi, gelecekte mühendislik veya bilim alanlarında başarılı olabileceğinin bir işaretidir.";
                recommendation = "Belediyemizin <strong>Robotik Kodlama</strong> ve <strong>Bilim Atölyesi</strong> kursları, bu yeteneği geliştirmek için harika bir başlangıç olacaktır.";
            }
            else if (trait.Contains("Sanat"))
            {
                paragraph1 = "Çocuğunuzun <strong>Sanatsal Zekası</strong> ön plana çıkmaktadır. Görsel hafızası, renkleri kullanımı ve hayal dünyasının zenginliği dikkat çekici. Kendini ifade etme biçimi olarak sanatı seçmesi, yaratıcı endüstrilerde parlak bir geleceğe sahip olabileceğini gösteriyor.";
                recommendation = "Yaratıcılığını desteklemek için <strong>Resim Atölyesi</strong> veya <strong>Drama</strong> kurslarına katılmasını şiddetle öneririz.";
            }
            else if (trait.Contains("Doğa"))
            {
                 paragraph1 = "Çocuğunuz doğaya ve canlılara karşı yüksek bir <strong>Doğa Zekası</strong> sergiliyor. Çevresindeki dünyayı keşfetme arzusu, bitkiler ve hayvanlarla olan empati yeteneği çok güçlü. Bu özellikler, biyoloji, çevre bilimleri veya veterinerlik gibi alanlara yatkınlığını gösterir.";
                 recommendation = "Doğa ile bağını güçlendirmek için <strong>İzcilik Kampı</strong> veya <strong>Çevre Kulübü</strong> etkinliklerimiz tam ona göre.";
            }
             else if (trait.Contains("Sosyal"))
            {
                 paragraph1 = "Çocuğunuzun <strong>Sosyal Zekası</strong> oldukça gelişmiş durumda. İnsan ilişkilerindeki başarısı, empati yeteneği ve grup içerisindeki liderlik vasıfları onu öne çıkarıyor. İletişim becerileri, geleceğin yöneticisi veya eğitimcisi olabileceğinin sinyallerini veriyor.";
                 recommendation = "Liderlik ve strateji becerilerini pekiştirmek için <strong>Satranç</strong> veya <strong>Drama</strong> kursları faydalı olacaktır.";
            }
            else // Spor/Bedensel
            {
                 paragraph1 = "Çocuğunuzda yüksek bir <strong>Bedensel (Kinestetik) Zeka</strong> görülmektedir. Enerjisi, koordinasyonu ve fiziksel aktivitelere olan yatkınlığı harika. Spor ve hareket gerektiren aktivitelerde kendini çok daha iyi ifade ediyor ve öğreniyor.";
                 recommendation = "Enerjisini doğru yönlendirmek ve disiplin kazanması için <strong>Yüzme</strong>, <strong>Okçuluk</strong> veya <strong>Basketbol</strong> kurslarımıza yönlendirebilirsiniz.";
            }

            return $@"
            <p>Sayın Veli,</p>
            <p>{paragraph1}</p>
            <p><strong>Gelişim Tavsiyesi:</strong> Çocuğunuzun bu baskın yeteneğini desteklemek, özgüvenini artıracak ve potansiyelini en üst düzeye çıkaracaktır. İlgi duyduğu alanlarda ona fırsatlar sunmanız çok değerlidir.</p>
            <p><strong>Kurs Önerisi:</strong> {recommendation}</p>
            <p>Saygılarımızla,<br>Başkan Sensin Eğitim Ekibi</p>";
        }
    }
}
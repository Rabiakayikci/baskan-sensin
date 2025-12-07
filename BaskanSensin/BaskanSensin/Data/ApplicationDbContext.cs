
using Microsoft.EntityFrameworkCore;
using BaskanSensin.Models;


namespace BaskanSensin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Yetenek> Yetenekler { get; set; }
        public DbSet<Yapi> Yapilar { get; set; }
        public DbSet<Soru> Sorular { get; set; }
        public DbSet<Secenek> Secenekler { get; set; }
        public DbSet<HaritaKayit> HaritaKayitlari { get; set; }
        public DbSet<Skor> Skorlar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Yetenek>().HasData(
                new Yetenek { Yetid = 1, Yetad = "Analitik Zeka" },
                new Yetenek { Yetid = 2, Yetad = "Sanatsal Zeka" },
                new Yetenek { Yetid = 3, Yetad = "Doğa Zekası" },
                new Yetenek { Yetid = 4, Yetad = "Sosyal Zeka" },
                new Yetenek { Yetid = 5, Yetad = "Bedensel Zeka" }
            );

            modelBuilder.Entity<Yapi>().HasData(
                new Yapi
                {
                    Yapid = 1,
                    Binaad = "Hastane",
                    Resim = "hastane.jpeg",
                    Beklemesuresi = 15, 
                    BilgiKarti = "Hastane, insanların daha sağlıklı olması için onlara yardım eden büyük ve önemli bir binadır.\r\nBu bina, hasta veya yaralı olduğumuz zamanlarda  iyileşmemize yardım eden ve doktorların, hemşirelerin ve diğer sağlık kahramanlarının çalıştığı özel bir yerdir. ",
                   
                },
                new Yapi
                {
                    Yapid = 2,
                    Binaad = "Mühendislik Ofisi",
                    Resim = "muhendis.jpeg",
                    Beklemesuresi = 15,
                    BilgiKarti = "Şehirdeki  yolları, kaldırımları ve parkları  yapan, bozulan yerleri tamir eden ve herkesin güvenle yürümesini sağlayan yerdir.",
                    
                },
                   new Yapi
                   {
                       Yapid = 3,
                       Binaad = "Avukatlık Bürosu",
                       Resim = "adalet.jpeg",
                       Beklemesuresi = 15,
                       BilgiKarti = "Avukatlar,  insanların kurallara uygun ve adil bir şekilde muamele görmesini sağlamak için çalışırlar. ",

                   },
                new Yapi
                {
                    Yapid = 4,
                    Binaad = "Sanat Atölyesi",
                    Resim = "sanat.jpeg",
                    Beklemesuresi = 15,
                    BilgiKarti = "İnsanların fikirleri gerçeğe dönüştürdüğü ve hayatımızı daha güzel, eğlenceli ve ilginç hale getirildiği yerlerdir. Bu yerlerde resim, müzik, tiyatro gibi birçok alanda çalışmalar yapılır.",

                },

                  new Yapi
                  {
                      Yapid = 5,
                      Binaad = "Spor Salonu",
                      Resim = "gym.jpeg",
                      Beklemesuresi = 15,
                      BilgiKarti = "İnsanların vücutlarını güçlendirmek için koştuğu, zıpladığı ve egzersiz yaptığı yerdir.",

                  }
            );

            modelBuilder.Entity<Soru>().HasData(
                new Soru
                {
                    Soruid = 1,
                    Metin = "Sevgili Başkan! Seninle şehrimizin ilk binasını oluşturmak istiyorum ama nereden başlayacağım konusunda kafam karışık. Haydi bize bir bina seç ve birlikte şehrimizin ilk binasını inşa etmeye başlayalım."
                },
        
                new Soru
               {
                   Soruid = 2,
                   Metin = "Mühendislik ofisimize devlet tarafından büyük bir fon tanımlandı. Ekibiniz bu fonu kullanmak üzere beş farklı proje önerisi sundu. Şimdi seninle bu farklı proje alanlarını inceleyeceğiz.\n\nBaşkanım, bu önemli kaynağı şehrin gelecekteki ruhunu oluşturmak için hangi projeye yatırmalıyız?"
                },
        
                new Soru
                {
                   Soruid = 3,
                   Metin = "Başkanım! Şehrin en eski su borusu büyük bir yağmurda patladı! Kirli su, şehirdeki parkın ve oyun alanının etrafını sardı. İnsanlar üzgün ve hasta olmaktan korkuyor. Senin mühendislik bilgin bu şehrin kaderini değiştirebilir.\n\nBaşkanım, yardımcılarınıza ilk olarak hangi ışık hızında emri verirsiniz?"
                 },
        
                new Soru
               {
                   Soruid = 4,
                   Metin = "Başkanım yaptığımız çalışmalar devletimiz tarafından büyük bir övgüyle karşılanıyor. Mühendis arkadaşlarınız tarafından da oldukça popülersiniz. Bir mühendis arkadaşımız yardımcı olmamız için bazı projeler gönderdi. Bu projelerden hangisini kabul etmeliyiz?"
               },
       
                new Soru
               {
                   Soruid = 5,
                   Metin = "Vay canına, Başkanım! Hayal gücümüzü kullanarak gerçekleştireceğimiz sihirli bir göreve hazır mısın? Şehrinize, anında ve kalıcı olarak mucizeler yaratabilen 'Süper Dönüşüm Kristali' siz başarılı mühendisimize hediye edildi. Bu kristal, şehrin sadece tek bir özelliğini mükemmel bir hale getirecek.\n\nSüper Kahraman Başkanım, şehrinizi geleceğe ışınlamak için bu tek ve güçlü kristali hangi alanda kullanırsınız?"
               },
       
                new Soru
               {
                   Soruid = 6,
                   Metin = "Başkanım, uluslararası bir rapor, şehrimiz için kırmızı alarm verdi! Şehrinizin gençleri, gelecekteki küresel rekabetteki en kritik becerilerde (eleştirel düşünme, ekip çalışması, fiziksel sağlık) diğer büyük şehirlerin gerisinde kalmış durumda. Mevcut eğitim ve gelişim sistemi artık çağın gereklerini karşılayamıyor.\n\nBaşkanım, şehrin gençlerini hızla geleceğe hazırlamak ve bu krizi tersine çevirmek için hangi köklü reformu başlatırsınız?"
                },



                new Soru
                {
                    Soruid = 7,
                    Metin = "Yeni hastanen harika görünüyor Başkan! Hadi hastanene yeni çalışanlar ekleyip daha güzel hizmet verelim. İlk önce kimi işe alalım?"
                },
       
                new Soru
               {
                    Soruid = 8,
                    Metin = "Merhaba Başkan! Yeni hastanemize hastalar gelmeye başladı. Giriş kapısına yeni bir cihaz almalıyız. Hangisinden başlayalım?"
                },
        
                new Soru
               {
                    Soruid = 9,
                    Metin = "Başkan hastanemiz çok iyi durumda ama kış geliyor. Tedbirimizi elden bırakmamalıyız. Kış mevsimine ve artacak hastalara hazırlanmalıyız. Nereden başlayalım?"
               },
        
                new Soru
               {
                    Soruid = 10,
                    Metin = "Başkan, bayram yaklaşıyor. Hastanedeki çalışanlar bizim için çok önemli. Onları ve ailelerini mutlu etmek için hastane çalışanlarına bir hediye belirleyelim!"
                },
       
                new Soru
               {
                   Soruid = 11,
                   Metin = "HAY AKSİ! Hastanemiz tüm imkanlarını halka sağlamak için çok çalışıyor ama yolunda gitmeyen bir şeyler var. Başkan, hastanede aniden elektrikler kesildi. Şu an ne yapmalıyız? Yardımınıza ihtiyacım var."
               },

                new Soru
               {
                   Soruid = 12,
                   Metin = "Şehrin hemen dışındaki bir otoyolda büyük bir zincirleme kaza oldu. Durumu ağır olan hastalar dâhil çok sayıda yaralı var ve acil servise aynı anda akın etmeye başladılar. Hastanemizdeki yatak ve personel kapasitesi hızla yetersiz gelmeye başlıyor. Başkanım, yardımcılarınıza ilk olarak hangi emri verirsiniz?"
                }

            );


            modelBuilder.Entity<Secenek>().HasData(
                new Secenek { Secenekid = 1, Soruid = 1, Metin = "Mühendislik Ofisi", Yetid = 1 }, 
        new Secenek { Secenekid = 2, Soruid = 1, Metin = "Hastane", Yetid = 2 },           
        new Secenek { Secenekid = 3, Soruid = 1, Metin = "Avukatlık Ofisi", Yetid = 3 },   
        new Secenek { Secenekid = 4, Soruid = 1, Metin = "Sanat Atölyesi", Yetid = 4 },    
        new Secenek { Secenekid = 5, Soruid = 1, Metin = "Spor Salonu", Yetid = 5 },      

        
        new Secenek { Secenekid = 6, Soruid = 2, Metin = "Tüm mahallelere ücretsiz internet erişim ağı kurulması", Yetid = 1 }, 
        new Secenek { Secenekid = 7, Soruid = 2, Metin = "Şehrin tanıtımı için bir sanat festivali", Yetid = 2 },             
        new Secenek { Secenekid = 8, Soruid = 2, Metin = "Şehirdeki tüm boş alanların kent bahçelerine dönüştürülmesi", Yetid = 3 }, 
        new Secenek { Secenekid = 9, Soruid = 2, Metin = "Yaşlılar için Destek Programları", Yetid = 4 },                    
        new Secenek { Secenekid = 10, Soruid = 2, Metin = "Şehir içi ulaşım için yüksek hızlı tramvay hattı projesi", Yetid = 5 }, 

       
        new Secenek { Secenekid = 11, Soruid = 3, Metin = "Temiz Su Arabaları Çağırma: Şehrin dört bir yanına temiz su dağıtan büyük tankerler göndeririz.", Yetid = 1 }, 
        new Secenek { Secenekid = 12, Soruid = 3, Metin = "Kırmızı Uyarı Bantları Çekme: Tüm kirli su basan sokaklara 'TEHLİKE!' bantları çekeriz.", Yetid = 2 },
        new Secenek { Secenekid = 13, Soruid = 3, Metin = "Dev Sünger Robotlar: Hızla çalışan, tüm suyu emen Dev Sünger Robotları icat edip göndeririz.", Yetid = 3 }, 
        new Secenek { Secenekid = 14, Soruid = 3, Metin = "Toprak Setler ve Akış Yönlendirme: Doğal toprak kullanarak geçici setler oluştururuz.", Yetid = 4 }, 
        new Secenek { Secenekid = 15, Soruid = 3, Metin = "Acil Vanayı Manüel Kapatma: Vanayı bizzat, elle ve en hızlı şekilde kapatmaları için talimat veririz.", Yetid = 5 }, 

        
        new Secenek { Secenekid = 16, Soruid = 4, Metin = "Gelecek Teknolojileri Araştıran Bir Merkez", Yetid = 1 }, 
        new Secenek { Secenekid = 17, Soruid = 4, Metin = "'Şehrin Renkleri' isimli Açık Hava Sanat Atölyesi", Yetid = 2 }, 
        new Secenek { Secenekid = 18, Soruid = 4, Metin = "Şehir Merkezine Kent Ormanı Projesi", Yetid = 3 }, 
        new Secenek { Secenekid = 19, Soruid = 4, Metin = "Büyük bir Liderlik ve İletişim Akademisi", Yetid = 4 }, 
        new Secenek { Secenekid = 20, Soruid = 4, Metin = "Çok Amaçlı Spor Salonu", Yetid = 5 }, 

        new Secenek { Secenekid = 21, Soruid = 5, Metin = "Kişiye Özel Akıllı Öğretmen", Yetid = 1 }, 
        new Secenek { Secenekid = 22, Soruid = 5, Metin = "Rüya Şehri Projesi", Yetid = 2 }, 
        new Secenek { Secenekid = 23, Soruid = 5, Metin = "Canlı Bitkiler Alanı", Yetid = 3 }, 
        new Secenek { Secenekid = 24, Soruid = 5, Metin = "Konuşma Alanı", Yetid = 4 }, 
        new Secenek { Secenekid = 25, Soruid = 5, Metin = "Yer Çekimsiz Egzersiz Bölgesi", Yetid = 5 }, 

       
        new Secenek { Secenekid = 26, Soruid = 6, Metin = "Robotik ve Yapay Zeka Laboratuvarı Seferberliği", Yetid = 1 }, 
        new Secenek { Secenekid = 27, Soruid = 6, Metin = "'Tasarım Odaklı Düşünme' Müfredatı", Yetid = 2 }, 
        new Secenek { Secenekid = 28, Soruid = 6, Metin = "Zorunlu 'Açık Hava Okulları' Sistemi", Yetid = 3 }, 
        new Secenek { Secenekid = 29, Soruid = 6, Metin = "'Geleceğin Liderleri' Mentorluk Programı", Yetid = 4 }, 
        new Secenek { Secenekid = 30, Soruid = 6, Metin = "'Günde İki Saat Hareket' Eğitimi", Yetid = 5 }
        ,

        new Secenek { Secenekid = 31, Soruid = 7, Metin = "Laboratuvarda ölçümler yapacak bir biyolog", Yetid = 1 }, 
        new Secenek { Secenekid = 32, Soruid = 7, Metin = "Engelli bireylerin hastanede rahat hareket edebilmesi için alan yerleşimini geliştirecek bir mimar", Yetid = 2 }, 
        new Secenek { Secenekid = 33, Soruid = 7, Metin = "Terapi bahçesi tasarlayacak bir bahçıvan", Yetid = 3 },
        new Secenek { Secenekid = 34, Soruid = 7, Metin = "Çalışanları yönlendirecek poliklinik sorumlusu", Yetid = 4 }, 
        new Secenek { Secenekid = 35, Soruid = 7, Metin = "Ameliyatları yapacak bir cerrah", Yetid = 5 }, 

       
        new Secenek { Secenekid = 36, Soruid = 8, Metin = "Hastaların tansiyonunu ölçecek cihaz", Yetid = 1 }, 
        new Secenek { Secenekid = 37, Soruid = 8, Metin = "Hastaları yönlendirmek için dijital ekran sistemi", Yetid = 2 }, 
        new Secenek { Secenekid = 38, Soruid = 8, Metin = "Giriş odasının havasını temizleyecek makine", Yetid = 3 }, 
        new Secenek { Secenekid = 39, Soruid = 8, Metin = "Hastaların hangi doktora gideceğini söyleyen makine", Yetid = 4 }, 
        new Secenek { Secenekid = 40, Soruid = 8, Metin = "Yaşlı hastaların kolay taşınması için tekerlekli sandalye", Yetid = 5 }, 

        
        new Secenek { Secenekid = 41, Soruid = 9, Metin = "Günlük hasta artışlarını takip eden sistem", Yetid = 1 }, 
        new Secenek { Secenekid = 42, Soruid = 9, Metin = "Hastanede kaygan ve ıslak alanlara uyarı levhaları hazırlamak", Yetid = 2 }, 
        new Secenek { Secenekid = 43, Soruid = 9, Metin = "İç mekanda kış bahçesi tasarımı", Yetid = 3 }, 
        new Secenek { Secenekid = 44, Soruid = 9, Metin = "Hastalar artacağı için danışma çalışanlarının artırılması", Yetid = 4 },
        new Secenek { Secenekid = 45, Soruid = 9, Metin = "Buzlanma durumunda dış alanın nasıl temizleneceğini kararlaştırmak", Yetid = 5 }, 

       
        new Secenek { Secenekid = 46, Soruid = 10, Metin = "Puzzle seti", Yetid = 1 }, 
        new Secenek { Secenekid = 47, Soruid = 10, Metin = "Sanatsal bir tablo", Yetid = 2 }, 
        new Secenek { Secenekid = 48, Soruid = 10, Metin = "Gül Fidanı", Yetid = 3 }, 
        new Secenek { Secenekid = 49, Soruid = 10, Metin = "Üzerinde çalışanın isim ve soy ismi yazan bir ajanda", Yetid = 4 }, 
        new Secenek { Secenekid = 50, Soruid = 10, Metin = "Boyun masaj cihazı", Yetid = 5 }, 

      
        new Secenek { Secenekid = 51, Soruid = 11, Metin = "Elektrik kesintisinin nedenini araştırmak", Yetid = 1 }, 
        new Secenek { Secenekid = 52, Soruid = 11, Metin = "Karanlıkta parlayan acil çıkış kapısı levhalarını kontrol etmek", Yetid = 2 },
        new Secenek { Secenekid = 53, Soruid = 11, Metin = "Karanlık bölgelerde hastaların düşmemesi için taşınabilir ışıkların açılması", Yetid = 3 }, 
        new Secenek { Secenekid = 54, Soruid = 11, Metin = "Hasta ve yakınlarına “hepimiz kontrol altındayız” duyurusu yapmak", Yetid = 4 }, 
        new Secenek { Secenekid = 55, Soruid = 11, Metin = "Hastaları taşımak için acil destek ekibi yönlendirmek", Yetid = 5 },

        
        new Secenek { Secenekid = 56, Soruid = 12, Metin = "Ameliyathane ve Kritik Alan Stok Kontrolü", Yetid = 1 }, 
        new Secenek { Secenekid = 57, Soruid = 12, Metin = "Hızlı Acil Durum Noktası Kurulumu (Düzeni)", Yetid = 2 }, 
        new Secenek { Secenekid = 58, Soruid = 12, Metin = "Acil Durum Personel Çağrısı", Yetid = 4 }, 
        new Secenek { Secenekid = 59, Soruid = 12, Metin = "Doğal Ortamda Sakinleştirme", Yetid = 3 }, 
        new Secenek { Secenekid = 60, Soruid = 12, Metin = "Yatak Sayısını Arttırma", Yetid = 5 }


            );
        }
    }
}
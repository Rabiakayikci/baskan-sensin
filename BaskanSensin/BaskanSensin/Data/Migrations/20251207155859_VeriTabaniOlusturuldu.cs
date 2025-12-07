using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaskanSensin.Data.Migrations
{
    /// <inheritdoc />
    public partial class VeriTabaniOlusturuldu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Sorular",
                columns: table => new
                {
                    Soruid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorular", x => x.Soruid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeliId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Yapilar",
                columns: table => new
                {
                    Yapid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Binaad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BilgiKarti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beklemesuresi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yapilar", x => x.Yapid);
                });

            migrationBuilder.CreateTable(
                name: "Yetenekler",
                columns: table => new
                {
                    Yetid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yetad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetenekler", x => x.Yetid);
                });

            migrationBuilder.CreateTable(
                name: "Skorlar",
                columns: table => new
                {
                    Skorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cocukid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Analitikp = table.Column<int>(type: "int", nullable: false),
                    Sanatp = table.Column<int>(type: "int", nullable: false),
                    Dogap = table.Column<int>(type: "int", nullable: false),
                    Sosyalp = table.Column<int>(type: "int", nullable: false),
                    Sporp = table.Column<int>(type: "int", nullable: false),
                    Baskinyet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skorlar", x => x.Skorid);
                    table.ForeignKey(
                        name: "FK_Skorlar_Users_Cocukid",
                        column: x => x.Cocukid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HaritaKayitlari",
                columns: table => new
                {
                    Haritaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cocukid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Yapiid = table.Column<int>(type: "int", nullable: false),
                    Slotno = table.Column<int>(type: "int", nullable: false),
                    Beklemesuresi = table.Column<int>(type: "int", nullable: false),
                    Tamamlanmadurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaritaKayitlari", x => x.Haritaid);
                    table.ForeignKey(
                        name: "FK_HaritaKayitlari_Users_Cocukid",
                        column: x => x.Cocukid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HaritaKayitlari_Yapilar_Yapiid",
                        column: x => x.Yapiid,
                        principalTable: "Yapilar",
                        principalColumn: "Yapid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secenekler",
                columns: table => new
                {
                    Secenekid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soruid = table.Column<int>(type: "int", nullable: false),
                    Yetid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secenekler", x => x.Secenekid);
                    table.ForeignKey(
                        name: "FK_Secenekler_Sorular_Soruid",
                        column: x => x.Soruid,
                        principalTable: "Sorular",
                        principalColumn: "Soruid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Secenekler_Yetenekler_Yetid",
                        column: x => x.Yetid,
                        principalTable: "Yetenekler",
                        principalColumn: "Yetid");
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "Soruid", "Metin" },
                values: new object[,]
                {
                    { 1, "Sevgili Başkan! Seninle şehrimizin ilk binasını oluşturmak istiyorum ama nereden başlayacağım konusunda kafam karışık. Haydi bize bir bina seç ve birlikte şehrimizin ilk binasını inşa etmeye başlayalım." },
                    { 2, "Mühendislik ofisimize devlet tarafından büyük bir fon tanımlandı. Ekibiniz bu fonu kullanmak üzere beş farklı proje önerisi sundu. Şimdi seninle bu farklı proje alanlarını inceleyeceğiz.\n\nBaşkanım, bu önemli kaynağı şehrin gelecekteki ruhunu oluşturmak için hangi projeye yatırmalıyız?" },
                    { 3, "Başkanım! Şehrin en eski su borusu büyük bir yağmurda patladı! Kirli su, şehirdeki parkın ve oyun alanının etrafını sardı. İnsanlar üzgün ve hasta olmaktan korkuyor. Senin mühendislik bilgin bu şehrin kaderini değiştirebilir.\n\nBaşkanım, yardımcılarınıza ilk olarak hangi ışık hızında emri verirsiniz?" },
                    { 4, "Başkanım yaptığımız çalışmalar devletimiz tarafından büyük bir övgüyle karşılanıyor. Mühendis arkadaşlarınız tarafından da oldukça popülersiniz. Bir mühendis arkadaşımız yardımcı olmamız için bazı projeler gönderdi. Bu projelerden hangisini kabul etmeliyiz?" },
                    { 5, "Vay canına, Başkanım! Hayal gücümüzü kullanarak gerçekleştireceğimiz sihirli bir göreve hazır mısın? Şehrinize, anında ve kalıcı olarak mucizeler yaratabilen 'Süper Dönüşüm Kristali' siz başarılı mühendisimize hediye edildi. Bu kristal, şehrin sadece tek bir özelliğini mükemmel bir hale getirecek.\n\nSüper Kahraman Başkanım, şehrinizi geleceğe ışınlamak için bu tek ve güçlü kristali hangi alanda kullanırsınız?" },
                    { 6, "Başkanım, uluslararası bir rapor, şehrimiz için kırmızı alarm verdi! Şehrinizin gençleri, gelecekteki küresel rekabetteki en kritik becerilerde (eleştirel düşünme, ekip çalışması, fiziksel sağlık) diğer büyük şehirlerin gerisinde kalmış durumda. Mevcut eğitim ve gelişim sistemi artık çağın gereklerini karşılayamıyor.\n\nBaşkanım, şehrin gençlerini hızla geleceğe hazırlamak ve bu krizi tersine çevirmek için hangi köklü reformu başlatırsınız?" },
                    { 7, "Yeni hastanen harika görünüyor Başkan! Hadi hastanene yeni çalışanlar ekleyip daha güzel hizmet verelim. İlk önce kimi işe alalım?" },
                    { 8, "Merhaba Başkan! Yeni hastanemize hastalar gelmeye başladı. Giriş kapısına yeni bir cihaz almalıyız. Hangisinden başlayalım?" },
                    { 9, "Başkan hastanemiz çok iyi durumda ama kış geliyor. Tedbirimizi elden bırakmamalıyız. Kış mevsimine ve artacak hastalara hazırlanmalıyız. Nereden başlayalım?" },
                    { 10, "Başkan, bayram yaklaşıyor. Hastanedeki çalışanlar bizim için çok önemli. Onları ve ailelerini mutlu etmek için hastane çalışanlarına bir hediye belirleyelim!" },
                    { 11, "HAY AKSİ! Hastanemiz tüm imkanlarını halka sağlamak için çok çalışıyor ama yolunda gitmeyen bir şeyler var. Başkan, hastanede aniden elektrikler kesildi. Şu an ne yapmalıyız? Yardımınıza ihtiyacım var." },
                    { 12, "Şehrin hemen dışındaki bir otoyolda büyük bir zincirleme kaza oldu. Durumu ağır olan hastalar dâhil çok sayıda yaralı var ve acil servise aynı anda akın etmeye başladılar. Hastanemizdeki yatak ve personel kapasitesi hızla yetersiz gelmeye başlıyor. Başkanım, yardımcılarınıza ilk olarak hangi emri verirsiniz?" }
                });

            migrationBuilder.InsertData(
                table: "Yapilar",
                columns: new[] { "Yapid", "Beklemesuresi", "BilgiKarti", "Binaad", "Resim" },
                values: new object[,]
                {
                    { 1, 15, "Hastane, insanların daha sağlıklı olması için onlara yardım eden büyük ve önemli bir binadır.\r\nBu bina, hasta veya yaralı olduğumuz zamanlarda  iyileşmemize yardım eden ve doktorların, hemşirelerin ve diğer sağlık kahramanlarının çalıştığı özel bir yerdir. ", "Hastane", "hastane.jpeg" },
                    { 2, 15, "Şehirdeki  yolları, kaldırımları ve parkları  yapan, bozulan yerleri tamir eden ve herkesin güvenle yürümesini sağlayan yerdir.", "Mühendislik Ofisi", "garden.png" },
                    { 3, 15, "Avukatlar,  insanların kurallara uygun ve adil bir şekilde muamele görmesini sağlamak için çalışırlar. ", "Avukatlık Bürosu", "library.png" },
                    { 4, 15, "İnsanların fikirleri gerçeğe dönüştürdüğü ve hayatımızı daha güzel, eğlenceli ve ilginç hale getirildiği yerlerdir. Bu yerlerde resim, müzik, tiyatro gibi birçok alanda çalışmalar yapılır.", "Sanat Atölyesi", "garden.png" },
                    { 5, 15, "İnsanların vücutlarını güçlendirmek için koştuğu, zıpladığı ve egzersiz yaptığı yerdir.", "Spor Salonu", "gym.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Yetenekler",
                columns: new[] { "Yetid", "Yetad" },
                values: new object[,]
                {
                    { 1, "Analitik Zeka" },
                    { 2, "Sanatsal Zeka" },
                    { 3, "Doğa Zekası" },
                    { 4, "Sosyal Zeka" },
                    { 5, "Bedensel Zeka" }
                });

            migrationBuilder.InsertData(
                table: "Secenekler",
                columns: new[] { "Secenekid", "Metin", "Soruid", "Yetid" },
                values: new object[,]
                {
                    { 1, "Mühendislik Ofisi", 1, 1 },
                    { 2, "Hastane", 1, 2 },
                    { 3, "Avukatlık Ofisi", 1, 3 },
                    { 4, "Sanat Atölyesi", 1, 4 },
                    { 5, "Spor Salonu", 1, 5 },
                    { 6, "Tüm mahallelere ücretsiz internet erişim ağı kurulması", 2, 1 },
                    { 7, "Şehrin tanıtımı için bir sanat festivali", 2, 2 },
                    { 8, "Şehirdeki tüm boş alanların kent bahçelerine dönüştürülmesi", 2, 3 },
                    { 9, "Yaşlılar için Destek Programları", 2, 4 },
                    { 10, "Şehir içi ulaşım için yüksek hızlı tramvay hattı projesi", 2, 5 },
                    { 11, "Temiz Su Arabaları Çağırma: Şehrin dört bir yanına temiz su dağıtan büyük tankerler göndeririz.", 3, 1 },
                    { 12, "Kırmızı Uyarı Bantları Çekme: Tüm kirli su basan sokaklara 'TEHLİKE!' bantları çekeriz.", 3, 2 },
                    { 13, "Dev Sünger Robotlar: Hızla çalışan, tüm suyu emen Dev Sünger Robotları icat edip göndeririz.", 3, 3 },
                    { 14, "Toprak Setler ve Akış Yönlendirme: Doğal toprak kullanarak geçici setler oluştururuz.", 3, 4 },
                    { 15, "Acil Vanayı Manüel Kapatma: Vanayı bizzat, elle ve en hızlı şekilde kapatmaları için talimat veririz.", 3, 5 },
                    { 16, "Gelecek Teknolojileri Araştıran Bir Merkez", 4, 1 },
                    { 17, "'Şehrin Renkleri' isimli Açık Hava Sanat Atölyesi", 4, 2 },
                    { 18, "Şehir Merkezine Kent Ormanı Projesi", 4, 3 },
                    { 19, "Büyük bir Liderlik ve İletişim Akademisi", 4, 4 },
                    { 20, "Çok Amaçlı Spor Salonu", 4, 5 },
                    { 21, "Kişiye Özel Akıllı Öğretmen", 5, 1 },
                    { 22, "Rüya Şehri Projesi", 5, 2 },
                    { 23, "Canlı Bitkiler Alanı", 5, 3 },
                    { 24, "Konuşma Alanı", 5, 4 },
                    { 25, "Yer Çekimsiz Egzersiz Bölgesi", 5, 5 },
                    { 26, "Robotik ve Yapay Zeka Laboratuvarı Seferberliği", 6, 1 },
                    { 27, "'Tasarım Odaklı Düşünme' Müfredatı", 6, 2 },
                    { 28, "Zorunlu 'Açık Hava Okulları' Sistemi", 6, 3 },
                    { 29, "'Geleceğin Liderleri' Mentorluk Programı", 6, 4 },
                    { 30, "'Günde İki Saat Hareket' Eğitimi", 6, 5 },
                    { 31, "Laboratuvarda ölçümler yapacak bir biyolog", 7, 1 },
                    { 32, "Engelli bireylerin hastanede rahat hareket edebilmesi için alan yerleşimini geliştirecek bir mimar", 7, 2 },
                    { 33, "Terapi bahçesi tasarlayacak bir bahçıvan", 7, 3 },
                    { 34, "Çalışanları yönlendirecek poliklinik sorumlusu", 7, 4 },
                    { 35, "Ameliyatları yapacak bir cerrah", 7, 5 },
                    { 36, "Hastaların tansiyonunu ölçecek cihaz", 8, 1 },
                    { 37, "Hastaları yönlendirmek için dijital ekran sistemi", 8, 2 },
                    { 38, "Giriş odasının havasını temizleyecek makine", 8, 3 },
                    { 39, "Hastaların hangi doktora gideceğini söyleyen makine", 8, 4 },
                    { 40, "Yaşlı hastaların kolay taşınması için tekerlekli sandalye", 8, 5 },
                    { 41, "Günlük hasta artışlarını takip eden sistem", 9, 1 },
                    { 42, "Hastanede kaygan ve ıslak alanlara uyarı levhaları hazırlamak", 9, 2 },
                    { 43, "İç mekanda kış bahçesi tasarımı", 9, 3 },
                    { 44, "Hastalar artacağı için danışma çalışanlarının artırılması", 9, 4 },
                    { 45, "Buzlanma durumunda dış alanın nasıl temizleneceğini kararlaştırmak", 9, 5 },
                    { 46, "Puzzle seti", 10, 1 },
                    { 47, "Sanatsal bir tablo", 10, 2 },
                    { 48, "Gül Fidanı", 10, 3 },
                    { 49, "Üzerinde çalışanın isim ve soy ismi yazan bir ajanda", 10, 4 },
                    { 50, "Boyun masaj cihazı", 10, 5 },
                    { 51, "Elektrik kesintisinin nedenini araştırmak", 11, 1 },
                    { 52, "Karanlıkta parlayan acil çıkış kapısı levhalarını kontrol etmek", 11, 2 },
                    { 53, "Karanlık bölgelerde hastaların düşmemesi için taşınabilir ışıkların açılması", 11, 3 },
                    { 54, "Hasta ve yakınlarına “hepimiz kontrol altındayız” duyurusu yapmak", 11, 4 },
                    { 55, "Hastaları taşımak için acil destek ekibi yönlendirmek", 11, 5 },
                    { 56, "Ameliyathane ve Kritik Alan Stok Kontrolü", 12, 1 },
                    { 57, "Hızlı Acil Durum Noktası Kurulumu (Düzeni)", 12, 2 },
                    { 58, "Acil Durum Personel Çağrısı", 12, 4 },
                    { 59, "Doğal Ortamda Sakinleştirme", 12, 3 },
                    { 60, "Yatak Sayısını Arttırma", 12, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HaritaKayitlari_Cocukid",
                table: "HaritaKayitlari",
                column: "Cocukid");

            migrationBuilder.CreateIndex(
                name: "IX_HaritaKayitlari_Yapiid",
                table: "HaritaKayitlari",
                column: "Yapiid");

            migrationBuilder.CreateIndex(
                name: "IX_Secenekler_Soruid",
                table: "Secenekler",
                column: "Soruid");

            migrationBuilder.CreateIndex(
                name: "IX_Secenekler_Yetid",
                table: "Secenekler",
                column: "Yetid");

            migrationBuilder.CreateIndex(
                name: "IX_Skorlar_Cocukid",
                table: "Skorlar",
                column: "Cocukid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VeliId",
                table: "Users",
                column: "VeliId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HaritaKayitlari");

            migrationBuilder.DropTable(
                name: "Secenekler");

            migrationBuilder.DropTable(
                name: "Skorlar");

            migrationBuilder.DropTable(
                name: "Yapilar");

            migrationBuilder.DropTable(
                name: "Sorular");

            migrationBuilder.DropTable(
                name: "Yetenekler");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}

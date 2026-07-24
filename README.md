# 🍽️ Lezzet Bahçesi — Restoran Yönetim Sistemi

ASP.NET Core MVC ve PostgreSQL üzerine kurulu, hem **admin/personel yönetim paneli** hem de **müşteri tarafı web sitesi** içeren tam kapsamlı bir restoran yönetim sistemi. Rol bazlı yetkilendirme, kategori/ürün/rezervasyon/sipariş/değerlendirme yönetimi ve detaylı istatistik paneli barındırır.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-336791?logo=postgresql&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-8.0-512BD4)
![Identity](https://img.shields.io/badge/ASP.NET%20Core-Identity-5C2D91)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📌 Proje Hakkında

Bu proje, bir restoranın hem **operasyonel yönetimini** (menü, sipariş, rezervasyon, değerlendirme, kullanıcı) hem de **müşteriyle etkileşimini** (menü görüntüleme, online rezervasyon, yorum bırakma, üyelik) tek bir sistem üzerinden yürütmesini sağlar.

Sistem iki ana yüzden oluşur:

- **Admin / Yönetim Paneli** — Restoran çalışanlarının (yönetici, şef, aşçı, garson, komi) menüyü, siparişleri, rezervasyonları ve müşteri geri bildirimlerini yönettiği kontrol paneli.
- **Müşteri Arayüzü** — Ziyaretçilerin menüyü kategori kategori inceleyip online rezervasyon yapabildiği, üye olup geçmiş rezervasyon/yorumlarını görebildiği ve ürünlere değerlendirme bırakabildiği halka açık site.

---
### 🌐 Müşteri Arayüzü (UI)
- Kategorilere göre gruplanmış **menü sayfası**
- **Kategori listesi** ve **kategori detay** sayfaları (seçilen kategorinin ürünlerini gösterir)
- **Rezervasyon formu** (gönderim sonrası aynı sayfada teşekkür mesajı)
- **Yorum yapma formu** (ürün seçimi + yıldız puanlama)
- Tutarlı görsel kimlik: Lora & Poppins yazı tipleri, sıcak/altın renk paleti

# <img width="1349" height="758" alt="UICategory" src="https://github.com/user-attachments/assets/e2838e63-3d36-44cb-a5b3-a184032fe659" />
# <img width="1366" height="768" alt="UICategory2" src="https://github.com/user-attachments/assets/a3363550-ede7-4e8b-bd25-b9ae6f50e784" />
# <img width="1346" height="765" alt="Menu1" src="https://github.com/user-attachments/assets/ce1ddebf-a0bb-4537-9123-2f6d20ba154c" />
# <img width="1060" height="383" alt="Menu3" src="https://github.com/user-attachments/assets/6591f941-2097-491e-8a50-42593ecee5a1" />
# <img width="1352" height="754" alt="UIReservation" src="https://github.com/user-attachments/assets/3d5ef43f-d3d5-4adf-b4d4-511442705165" />
# <img width="1352" height="760" alt="UIRewies" src="https://github.com/user-attachments/assets/2ff3c3f2-4569-4db4-8f3c-7cdfe0a00df5" />

## ✨ Özellikler

### 🔑 Kimlik Doğrulama ve Yetkilendirme
- ASP.NET Core Identity ile e-posta/şifre tabanlı **kayıt ol / giriş yap** sistemi
- 7 farklı rol: **Admin, Müdür, Şef, Aşçı, Garson, Komi, Müşteri**
- Rol bazlı erişim kontrolü (`[Authorize(Roles = "...")]`) — her personel rolü yalnızca yetkili olduğu admin işlemlerine erişebilir
- Özelleştirilmiş **404**, **403 (Erişim Reddedildi)** ve **500** hata sayfaları
- Müşteri tarafında **"Hesabım"** sayfası — kullanıcının kendi rezervasyon ve yorum geçmişini görebilmesi

# <img width="501" height="438" alt="Login" src="https://github.com/user-attachments/assets/70759266-05eb-4272-ac41-8d3be73b1475" />
# <img width="443" height="438" alt="Register" src="https://github.com/user-attachments/assets/7f1acc23-3cd5-4dde-bf32-bb1b59dbe381" />
# <img width="652" height="467" alt="Error404" src="https://github.com/user-attachments/assets/e2f9f5bb-ad9d-4e06-880d-5f70dff07ccb" />
# <img width="699" height="477" alt="AccessDenield" src="https://github.com/user-attachments/assets/9e23b7bb-f850-4d07-8a45-f981c9669315" />

### 🗂️ Kategori Yönetimi
- Kategori oluşturma, düzenleme, silme
- Aktif/Pasif durum kontrolü, kategori bazlı görsel

# <img width="1366" height="768" alt="Category" src="https://github.com/user-attachments/assets/fe5eca03-8b50-4dae-ab85-6a0904859839" />

### 🍔 Ürün (Menü) Yönetimi
- Ürün CRUD işlemleri (isim, açıklama, fiyat, görsel, kategori, durum)
- Arama, kategoriye göre filtreleme, fiyata/isme göre sıralama
- Aktif/pasif ürün istatistikleri

# <img width="1366" height="768" alt="Product" src="https://github.com/user-attachments/assets/5bbfde39-5afb-45c7-8f73-a1d1f0e40554" />

### 📅 Rezervasyon Yönetimi
- Müşteri tarafından online rezervasyon oluşturma (misafir veya üye)
- Admin tarafında onaylama / bekletme / iptal etme / tamamlama iş akışı
- Tarih, durum ve arama bazlı filtreleme
- Rezervasyon yoğunluğu ve durum dağılımı istatistikleri

# <img width="1366" height="768" alt="Reservation" src="https://github.com/user-attachments/assets/dbf8093e-87b9-4a41-a834-9eafd46fb488" />

### 🧾 Sipariş Yönetimi
- Masa bazlı sipariş oluşturma ve takibi
- Sipariş durumu güncelleme: Beklemede → Hazırlanıyor → Servis Edildi / İptal Edildi
- Ay/yıl bazlı filtreleme ve sayfalama

# <img width="1366" height="768" alt="Order" src="https://github.com/user-attachments/assets/d4f82b1b-b660-4fda-b32d-bc1159f233c4" />

### ⭐ Değerlendirme (Yorum) Sistemi
- Müşteriler ürün seçip yıldız puanı ve yorum bırakabilir
- **Admin onayı olmadan yorumlar yayına girmez** (moderasyon akışı)
- Yayında / gizli yorum ayrımı, puan dağılımı istatistiği

# <img width="1366" height="768" alt="Review" src="https://github.com/user-attachments/assets/3a06cc1a-d475-4ca1-b0ca-0b678fb1cd22" />

### 👥 Kullanıcı Yönetimi
- Kayıtlı tüm kullanıcıların listelendiği admin paneli
- E-posta onay durumu takibi, arama ve filtreleme

# <img width="1366" height="768" alt="UserList" src="https://github.com/user-attachments/assets/67d3c9c7-feec-483d-8936-8482942bbebf" />

### 📊 Dashboard & İstatistikler
- Genel bakış paneli: toplam rezervasyon, sipariş, ürün, müşteri sayıları
- Günlük rezervasyon grafiği, kategoriye göre ürün sayısı, kategori ortalama fiyatları (Chart.js)
- Detaylı istatistik sayfası: kategori performansı, puan dağılımı, en iyi ürünler, rezervasyon yoğunluk haritası (gün/saat), müşteri metrikleri (tekrar gelen müşteri oranı, yorum yapan müşteri oranı vb.)

# <img width="1286" height="2458" alt="Dashboard" src="https://github.com/user-attachments/assets/f2f592ac-6fbc-4690-a35f-79f92c6cc414" />
# <img width="1348" height="1294" alt="Statistic1" src="https://github.com/user-attachments/assets/edfd60e3-09d4-4d49-86f2-64ed99a771f4" />
# <img width="1287" height="1281" alt="Statistic2" src="https://github.com/user-attachments/assets/2579ade6-a369-4819-99e2-7b8ea099d846" />



---

## 🛠️ Kullanılan Teknolojiler

| Katman | Teknoloji |
|---|---|
| Backend | ASP.NET Core MVC (.NET 8) |
| Veritabanı | PostgreSQL |
| ORM | Entity Framework Core 8 + Npgsql.EntityFrameworkCore.PostgreSQL |
| Kimlik Doğrulama | ASP.NET Core Identity (rol tabanlı) |
| Nesne Eşleme | AutoMapper |
| Frontend (Admin) | Bootstrap, özel CSS bileşenleri, Chart.js |
| Frontend (Müşteri) | Bootstrap, Font Awesome, Google Fonts (Lora, Poppins), View Component mimarisi |
| Migration | EF Core Code-First Migrations |

---

## 🏗️ Proje Mimarisi

Katmanlı bir mimari izlenmiştir:

```
DinnerMenuPostgreSQL/
├── Context/            → AppDbContext (IdentityDbContext tabanlı)
├── Controllers/         → Admin ve müşteri tarafı controller'lar
├── Data/                → IdentitySeeder (rol ve admin kullanıcı seed işlemleri)
├── Dtos/                → Her modül için Create/Update/Result/GetById DTO'ları
├── Entities/            → Category, Product, Reservation, Review, Order, OrderItem, ApplicationUser
├── Mapping/             → AutoMapper profilleri (GeneralMapping)
├── Migrations/          → EF Core migration dosyaları
├── Service/             → Interface + implementasyon bazlı servis katmanı
├── ViewComponents/       → Dashboard, Menü, Chart, İstatistik için paylaşılan bileşenler
├── Views/               → Admin ve müşteri tarafı Razor view'ları
└── Program.cs           → Servis kayıtları, middleware pipeline, Identity & seed
```

---

**Servis Katmanı:** Her modül (Category, Product, Reservation, Review, Order, Dashboard, Chart) kendi `I{Modül}Service` arayüzü ve implementasyonuna sahiptir — controller'lar doğrudan `DbContext` yerine servis katmanı üzerinden çalışır.

**DTO Kullanımı:** Entity'ler doğrudan view'lara gönderilmez; her işlem için ayrı `CreateDto`, `UpdateDto`, `ResultDto`, `GetByIdDto` sınıfları tanımlanmış ve AutoMapper ile eşlenmiştir.

---

## 🔐 Roller ve Yetkilendirme

| Rol | Yetki Alanı |
|---|---|
| **Admin** | Sistemin tamamına tam erişim |
| **Müdür** | Operasyonel yönetim (kategori, ürün, rezervasyon, sipariş, değerlendirme onayı) |
| **Şef** | Menü ve kategori yönetimi |
| **Aşçı** | Sipariş durumu güncelleme |
| **Garson** | Sipariş ve rezervasyon durumu güncelleme |
| **Komi** | Sipariş görüntüleme/destek işlemleri |
| **Müşteri** | Rezervasyon oluşturma, yorum yapma, kendi hesabını görüntüleme |

Yetkisiz bir sayfaya erişim denemesi özelleştirilmiş **403 Erişim Reddedildi** sayfasına yönlendirilir.

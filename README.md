# 🌍 JadooTravel

**JadooTravel**, kullanıcıların gezilecek yerleri keşfedebileceği, çok dilli destek sunan, modern bir **ASP.NET Core MVC** projesidir.  
Proje **MongoDB (NoSQL)** veritabanı kullanılarak geliştirilmiş olup, **code-first yaklaşımı**, **katmanlı mimari yapısı**, **ViewComponent kullanımı** ve **bağımlılık enjeksiyonu (Dependency Injection)** prensipleriyle tasarlanmıştır.

---

## 🚀 Özellikler

- 🌐 **Çok Dilli Destek (4 Dil)**
  - Kullanıcı arayüzü İngilizce, Türkçe, Fransızca ve İspanyolca dillerinde hizmet verir.
  - Seçilen dile göre içerikler dinamik olarak çevirilir.
  - Dil desteği `TranslatorService` üzerinden sağlanmıştır:
  

- 🧩 **ViewComponent Kullanımı**
  - UI bileşenleri yeniden kullanılabilir hale getirilmiştir.
  - Kod tekrarını önlemek ve dinamik verilerle çalışmak için kullanılmıştır.
  - Parçala-böl-yönet prensibi benimsenmiştir.

- 🧱 **Folder Structure**
  - Proje dosya yapısı dikkatli şekilde organize edilmiştir:
    ```
    JadooTravel/
    ├── Controllers/
    ├── Entities/
    ├── DTOs/
    ├── Services/
    ├── Settings/
    ├── ViewComponents/
    ├── Views/
    ├── wwwroot/
    ├── Program.cs
    └── appsettings.json
    ```

- 🧠 **Dependency Injection (Bağımlılık Enjeksiyonu)**
  - Servisler arası bağımlılıklar `AddScoped` kullanılarak yönetilmiştir.
  

- ⚙️ **Code First Yaklaşımı**
  - MongoDB ile code-first prensibi benimsenmiştir.
  - Entity, DTO ve Service katmanları arasında temiz bir ayrım vardır.

- 🗄️ **MongoDB NoSQL Veritabanı**
  - Proje verilerini saklamak için MongoDB kullanılmıştır.
  - Veritabanı ayarları `Settings/DatabaseSetting.cs` sınıfında yönetilir:
    ```csharp
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string DestinationCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string ReservationCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string UserReservationCollectionName { get; set; }
    }
    ```

---

## 🧩 Kullanılan Teknolojiler

| Katman / Araç | Teknoloji |
|----------------|------------|
| Backend | ASP.NET Core MVC (.NET 8) |
| Veritabanı | MongoDB (NoSQL) |
| ORM Yaklaşımı | Code First |
| DI Yönetimi | Scoped Services |
| UI Bileşenleri | ViewComponents |
| Çeviri | TranslatorService |
| Dil Desteği | 4 farklı dil |

---

## 🧠 Mimarinin Temel Mantığı

- **Entities** → MongoDB koleksiyonlarını temsil eden veri modelleri.  
- **DTOs** → Veri transfer nesneleri (Data Transfer Objects).  
- **Services** → Veritabanı işlemlerini yöneten iş katmanı.  
- **Settings** → Veritabanı bağlantı ayarlarını yöneten yapı.  
- **ViewComponents** → Sayfa üzerinde dinamik olarak çalışan UI bileşenleri.  
- **Controllers** → Kullanıcı isteklerini işleyip View veya JSON dönen denetleyiciler.  

---

## 💡 Örnek Akış

1. Kullanıcı siteye giriş yaptığında sistem varsayılan dili yükler.  
2. Kullanıcı dil seçimini değiştirdiğinde, `TranslatorService` seçilen dile göre metinleri çevirir.  
3. Veriler MongoDB üzerinden getirilir.  
4. ViewComponent’ler ilgili kısımlarda dinamik içerikleri render eder.  


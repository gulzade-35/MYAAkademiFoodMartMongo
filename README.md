🛒 FoodMart MongoDB Projesi

FoodMart, ASP.NET Core 8.0 ve MongoDB ile geliştirilmiş, dinamik bir e-ticaret platformudur.
Hem kullanıcı dostu bir web sitesi hem de yönetim için kapsamlı bir admin paneli içerir.

👩‍💻 Kullanıcı Arayüzü

💸 Tüm Ürünler: Ürün ve kategoriler ayrı olarak gösterilir.
📈 Uygun Fiyatlı Ürünler: En uygun ürünler ana sayfada listelenir.
📧 İndirim Kodu Mail Gönderimi: Kullanıcılar e-posta adreslerini girerek indirim kodu alabilir.
Mail gönderimi MailKit kütüphanesi ile güvenli ve hızlı şekilde sağlanır.

🔐 Admin Paneli Özellikleri
🔑 Giriş/Çıkış: Admin, kullanıcı adı ve şifreyle sisteme giriş yapabilir.

📝 Kategori Yönetimi: Kategori ekleme, silme, güncelleme, listeleme.

🛍️ Ürün Yönetimi: Ürünlerin eklenmesi, silinmesi, güncellenmesi.

💰 İndirim Yönetimi: Ürün ve kategori bazında indirimler tanımlanabilir.

🛠️ Kullanılan Teknolojiler ve Yapılar

💻 ASP.NET Core 8.0: Microsoft’un modern, açık kaynaklı web uygulama framework’ü ve admin paneli bu altyapı ile geliştirildi.
🍃 MongoDB: NoSQL, doküman tabanlı veritabanı. Ürün, kategori, satış ve kullanıcı verileri koleksiyon yapısıyla yönetildi.
🔄 AutoMapper: Nesne-to-nesne dönüştürme kütüphanesi. DTO ve entity sınıfları arasındaki dönüşümler sadeleştirildi.
📦 DTO (Data Transfer Objects): Veri transferini optimize eden veri modeli. Katmanlar arası veri aktarımında kullanılarak güvenlik ve performans artırıldı.
✉️ MailKit: SMTP protokolü ile e-posta gönderimi sağlayan kütüphane. Kullanıcılara indirim kodu otomatik olarak e-posta ile gönderildi.
🌐 ViewComponent: Modüler yapı için Razor bileşenleri. Slider, öne çıkanlar, indirimli ürünler gibi alanlar bu yapı ile dinamikleştirildi.
🗂️ Session Management: Oturum yönetimi mekanizması. Admin giriş/çıkış ve kullanıcı doğrulama işlemleri oturum üzerinden kontrol edildi.

<img width="1628" height="882" alt="Image" src="https://github.com/user-attachments/assets/63a8c376-3e77-4674-ac28-27de1e0c5798" />

<img width="1602" height="412" alt="Image" src="https://github.com/user-attachments/assets/89d37d67-a190-470e-8e46-b94840f7253e" />

# Patika+ Çılgın Müzisyenler Uygulaması (API)
Bu proje C# MVC ile geliştirilmiştir. Temel API kullanımı mevcuttur.

## Görev
![TTZx4B9-cilginmuzisyenler](https://github.com/user-attachments/assets/61dad684-10d9-4acb-aea8-5963985b2cfc)

Yukarıda verilen komik ve eğlenceli veri tablosunu kullanarak bir ASP.NET Core Web API oluşturunuz.

API, temel CRUD (Create, Read, Update, Delete) işlemlerini desteklemelidir.

En az 2 Get - 1 Post - 1 Patch - 1 Put - 1 Delete Api'si açınız.

Routing işlemleri Haftalık Teknik İçerik 5'te yapılan örnekte işlendiği şekilde yapılmalı. Dilediğiniz şekilde Api'leri çeşitlendirebilir ve routeları ayarlayabilirsiniz.

Projeyi ingilizce olarak kodlayınız. ( Crazy Musicians ! )

Gerekli Validation işlemlerini gerçekleştirdiğinize emin olunuz.

En az bir [FromQuery] yapısı kullanınız. Search iyi bir örnek olabilir.

Routing aşamasında Galactic Tour uygulamasında yapılan genel geçer routing tarzını kullanmaya özen gösteriniz.


## Teknik Açıklama
- CRUD (Create, Read, Update, Delete) işlemleri tamamlandı:
  - GET: Müzisyenleri listeleme ve ID/isim arama.
  - POST: Yeni müzisyen ekleme.
  - PATCH: Kısmi güncelleme.
  - PUT: Tam güncelleme.
  - DELETE: Müzisyen silme.
    
- `string.IsNullOrWhiteSpace`:
  - Bu yöntem, bir string'in:
    - Boş ("") olup olmadığını,
    - Sadece boşluklardan oluşup oluşmadığını kontrol eder.
   - Örnek:
       `string.IsNullOrWhiteSpace(null);       // true  `
       `string.IsNullOrWhiteSpace("");         // true  `
       `string.IsNullOrWhiteSpace("   ");      // true  `
       `string.IsNullOrWhiteSpace("John");     // false  `
     
- Contains Kullanımı: Kullanıcı tam isim yerine ismin bir kısmını yazsa bile sonuç dönebilir.
    - Örnek Kod: (GET)
      `// Name içeren müzisyenleri filtrele (büyük/küçük harf duyarlılığı yok)
    var musicians = MusicianData.Musicians
        .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList(); // Listeye dönüştürüyoruz.`
    - Açıklama:
      - Örneğin, `name` değeri "Ahmet" yerine "Ah" girilirse, "Ahmet Çalgı" sonucu döner.

- Örnek Testler:
   | URL                             | Output                              |
   |---------------------------------|-------------------------------------|
   | `/api/musicians/musician/Ahmet` | Ahmet Çalgı                         |
   | `/api/musicians/musician/A`     | Ahmet Çalgı, Ali Perde              |
   | `/api/musicians/musician/Zey`   | Zeynep Melodi                       |
   | `/api/musicians/musician/X`     | NotFound                            |


- Routing Örneği:
   | Yöntem	                          | URL	                               | Açıklama                  |
   |--------------------------------------|------------------------------------|------------------------   |
   | GET	                          | api/musicians	               | Tüm müzisyenleri getir    |
   | GET                              	  | api/musicians/{id}	               | ID'ye göre müzisyen getir |
   | GET	                          | api/musicians/search?name=Ahmet    | İsimle müzisyen ara       |
   | POST	                          | api/musicians                      | Yeni müzisyen ekle        |
   | PUT	                          | api/musicians/{id}                 | Müzisyeni tamamen güncelle|
   | PATCH	                          | api/musicians/{id}	               | Müzisyeni kısmen güncelle |
   | DELETE	                          | api/musicians/{id}	               | Müzisyeni sil             |
		



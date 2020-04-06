Soru: [Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız? ]

Cevap: DB kısmında Repository Pattern kullandım.
Api kısmında Open Closed Principle uyguladım fakat detaylı olmadığı ve metotların çoğunluğu “Data” projesinde olduğu için Log kısmını Open Closed Principle’a göre gerçekleştirdim. Open Closed tercih etmemin sebebi bilindiği üzere sınıfın genişletilip metotların olduğu gibi kalmasıdır. Bu sayede olası bir geliştirme varolana dokunmadan ilerleyeceği için zaman ve performans kazancı sağlamak çok daha kolaydır.

Soru:[Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz? ]

Cevap: .Net Core ile ilk defa komple bir proje gerçekleştirdim. Authentication mekanizmasında kullandığım JWT ile ilgili olarak da daha önceki projelerimde Bearer Token yapısını kullandım. (Hem token oluşturarak hem de oluşturulan token ile request yaparak). .Net Core ilk kez kullandığım için Nuget’le yüklediğim  package’ları ilk kez kullandım.

Soru: [Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz? ]

Cevap: Yorum yapan kişiler için üyelik sistemi ve yorum yapabilmek - silebilmek ve güncellemek için de yine varolan sistemdeki gibi authentication yapısı hazırlanabilirdi. Log yapısına log seviyesi ekleyebilirdim. Uygulamaya güvenlik geliştirmeleri yapılabilirdi. Cache yapısını sadece Api versiyonunu çağırma metodunda kullandım. Diğer kısımlara da senaryolara göre eklenebilirdi. Proje listesinde istenmemiş ama UnitTest geliştirmesi yapılabilirdi. Yapılan tüm işlemler için mongodb gibi nosql veritabanıyla kayıt altına alınabilirdi.

Soru: [Eklemek istediğiniz bir yorumunuz var mı?]

Cevap: Bugüne kadar ki uygulamalarımı WebForms, .Net MVC ve .Net Web Api yapılarında hazırladım. İlk defa .Net Core tarafında geliştirme fırsatım oldu. Bunun yanında uygulama tamamen MacOS Mojave üzerinde hazırlandı. SQL için Docker kullanılarak SQL Server image’ı çalıştırıldı. SQL veritabanına Azure Data Studio uygulaması üzerinden erişim sağladım. Uygulamanın testleri Postman üzerinden yapıldı. Son olarak projeyi ortalama 2 iş günü (14-16 saat) gibi bir sürede tamamladım ve kod kısmı toplamda 3-4 saat gibi bir süre aldı geri kalanı araştırma ile geçti. 

İlginiz için teşekkür ederim.

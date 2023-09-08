# Bicycle-ntier-architecture
Bicycle web app - aspnetcore mvc

----Proje Kuruluşu----

-Bilgi-
1-Projeyi çalıştırmak için minimum visual studio 2019 gerekli.
2-Sql Server 2017 kullanıldı.Eski sürümler desteklenir.  
3-Proje Aspnetcore Mvc'de codefirst ile geliştirildi.

-Kuruluş-
1-Proje bilgisayarınıza indirdikten sonra visual studio açılır.
2-Projede çok katmanlı mimari kullanıldığı için package manager console açılarak Bicycle.DataAccess(önemli) projesi seçildikten sonra
(add-migration Init) komutu çalıştırılır.
3-Daha sonra yine package manager console'da (update-database) komutu çalıştırılır.
4-Proje genel olarak kullanıma hazırdır.

-Projenin İçeriği-
1-Proje bisiklet kiralama uygulamasını içermektedir.
2-Aspnercore mvc-Ntier architecture-OOP-Repository Pattern-Automapper-Identity-Entityframewrokcore-Pagedlist-Ajax-Bootstrap-Jquery kullanıldı.
3-Bisiklet kiralama, teslim etme , kiraladığı ve teslim ettiği bisiklet geçmişi, race condition durumu, kredi kartı veya puan ile ödeme(sanal pos yoktur.method içinde),
bisikleti teslim eden kullanıcı için ek puan,client side ve server side validation mevcuttur.
4-Race condition kullanım durumu şöyledir. 2 farklı kullanıcı olsun(X ve Y).Rusya-Moskova(örnek) istasyonunda 1 bisiklet kaldığını düşünelim.
X kullanıcısı Y'den önce Rusya-Moskova(örnek) istasyonunda KİRALA butonuna tıkladığında mevcut kullanıcı için arka planda kuyruğa ekleme yapılır.
Varsayılan bekleme süresi 10 dakikadır. 10 dakika içinde X kullanıcısı ödeme işlemi gerçekleştirmeze kuyruktan çıkar.
Daha sonra Y kullanıcısıda aynı istasyonda (Rusya-Moskova(örnek)) KİRALA butonuna tıkladığında Y kullanıcısıda kuyruğa eklenir. 
X kullanıcısı sayfayı açtı ama henüz ödeme gerçekleştirmeden Y kullanıcısı ödeme yaparsa kuyrukta ikinci sırada olduğundan ve istasyonda 1 bisiklet 
olduğundan bisikleti kiralayamayacaktır.
5-Kullanıcı bisikleti boş yer bulunan bir istasyona teslim edebilir ve +5 puan kazanır. 50 puan ödemesiyle bisiklet kiralayabilmektedir.
6-Proje ilk kez çalıştırıldığında api uç noktasından datalar çekilerek veritabanına kayıt edilmektedir.Program.cs içindeki ExternalData sınıfında bu işlem yapılmaktadır.
Eğer aynı verilerin tekrar yüklenmesini istemiyorsanız projeyi bir kez çalıştırdıktan sonra veriler çekilecek.Program.cs içerisinde ExternalData metodu yorum satırına alabilirsiniz. 

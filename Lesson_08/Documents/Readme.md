# Lesson_08 : Temel Dosya Yazma/Okuma İşlemleri ve Exception Handling

Eğitim dönemi boyunca ele aldığımız Kanban uygulaması, görev bilgilerini bu derse kadar in-memory tutacak şekilde tasarlanmıştı. Programların kullandığı verileri fiziki olarak saklamak için farklı çözümler söz konusu. Veritabanları bunlar arasında en yaygın olanlarındadır. Diğer yandan basit veri setleri fiziki dosyalarda da saklanabilir. Bu dersteki amacımız temel dosyalama işlemlerini incelemek ve Kanban Board uygulamasındaki Task nesne dizilerini fiziki diskte nasıl saklayabileceğimize dair farklı teknikleri öğrenmektir. Örnek projemizde FileStream, StreamWriter ve StreamReader nesneleri kullanılarak bir dosyaya sıralı text ifadesi yazma ve okuma işlemleri ele alınmıştır. Ayrıca bu tip işlemlerde programın çökmesine neden olabilecek istisnaları ele almak için try...catch...finally bloklarından nasıl yararlanılabileceği ele alınmıştır.

## Sözlük

- **params** anahtar kelimesi ile bir metoda n sayıda parametre gönderebiliriz. Console sınıfının statik WriteLine metodu bunun en güzel örneklerindendir.
- **using** bloğu: IDisposable arayüzünü _(interface)_ uyarlayan tipler Dipose metodunu da override ederler. Genellikle sistem kaynakları kullanan nesneler bellekten atılırken Dispose bloklarında ilgili kaynak iade işlemleri de yapılır. using bloğu ile kullanılan nesne örneklerinde, blok sonuna gelindiğinde Dispose metotları otomatik olarak çağrılır. FileStream, StreamWriter gibi derste işlediğimiz sınıflar IDisposable arayüzünü uygulayan örneklerdendir. Dolayısıyla using bloğu ile birlikte kullanılabilirler.
- **exception ve stack trace** : Bir exception oluştuğunda geliştirici için Stack Trace'de önemli bilgiler yer alır. Stack Trace aşağıdan yukarı doğru okunur ve hangi metottan hangi metodun çağırıldığı, hangi satıra gelindiği okunabilir. Trace'in en tepe noktası Exception'ının fırlatıldığı yerdir.

## Yardımcı Linkler

_Ders sırasında uğradığımız sayfalar varsa linkleri paylaşılır_

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# Örnek projeyi açmak için
dotnet new console --use-program-main -o UsingFileOperations

# Örnek projeyi solution'a eklemek için
dotnet sln add Lesson_08/Projects/UsingFileOperations/

# proje veya çözümü derlemek için
dotnet build

# çalıştırmak için
dotnet run
```

## Çalışma Zamanı

Programa ait çalışma zamanı çıktısı aşağıdaki gibidir.

## Araştırsak iyi Olur

- FileStream dışında söz konusu olan NetworkStream, MemoryStream gibi sınıflar hangi senaryolarda kullanılır bakabiliriz.
- UsingFileOperations isimli örneğimizde FileNotFoundException durumunu da ele aldık. Buna gerek kalmadan dosyanın sistemde var olup olmadığını denetleyip ilerleyebiliriz de. Bunu nasıl yapabileceğimizi araştıralım.

## Evde Çalışmak için Atıştırmalıklar

- Okuduğunuz kitapların listesini text tabanlı dosyaya yazan ve okuyan bir program geliştirmeyi deneyebilirsiniz.

## Kazanımlar

- Temel dosyalama işlemleri. FileStream, StreamWriter ve StreamReader ile dosyaya yazma ve dosyadan okuma işlemleri.
- Basit anlamda istisna yönetimi *(Exception Handling)*
- using bloklarının kullanımı ve amacı.
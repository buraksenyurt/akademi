# Lesson_09 : Nesne Verilerini Depolama Biçimleri ve Koleksiyonların Fiziki Ortama Yazılıp/Okunması

Programlarda kullanılan ve bellekte tutulan nesne verileri çalışma zamanı sonlandığında doğal olarak kaybolurlar. Pek çok uygulama üzerinde çalışılan verilerin son hallerini tutabilmek için fiziki depolama ortamlarını kullanırlar. Kalıcı olarak saklanabilen bu verilerin aynı çalışma zamanı dışında özellikle dağıtık sistemlerin farklı çalışma zamanlarınca kullanılması gerektiği durumlar da söz konusu olabilir. Bu gibi durumlarda çeşitli türden veritabanı sistemleri kullanılır. _(Özellikle RDBMS-Relational Database Management Systems veya NoSQL)_

Ancak çok büyük boyutlu verilerin depolanmasında tek alternatif bu tip çözümler de değildir. Verinin dosya sisteminde farklı formatlarda tutulması da oldukça yaygındır. Ne var ki bu tip çözümlerde çok kullanıcılı çalışma ve dağıtık sistemlerde verinin paylaşılması gibi avantajlar kaybedilebilir. Hele ki verinin herkes için tutarlılığı ön planda ise. Tabii basit ihtiyaçlar için basit çözümler de pekala işe yarar.

Bu dersteki amaçlarımızdan birisi Kanban tahtamızdaki verileri bellekte tutan generic koleksiyon içeriğini dosya sistemine yazmak ve yine bu dosya sisteminden okuyarak kullanabilmektir. Bu amaçla .Net'in işleri kolaylaştıran sınıflarını kullanarak veriyi bir dosya sistemine farklı formatlarda nasıl yazabileceğimizi inceleyerek işe başlayacağız. Bir diğer amacımız da yazma/okuma işlemlerini üstlenen bileşenlerin artmasının ortaya çıkaracağı kod kirliliğini görmek ve bunun önüne geçmek için bağımlılıkları nasıl tersine çevirebileceğimizi anlamaktır. Bu ihtiyaçlar nesne yönelimli dil paradigmasının önemli öğelerinden olan interface türü ile nesne sözleşmelerinin hazırlanması ve nasıl kullanılıp ne gibi problemleri çözdüğünün anlaşılması açısından da bize bir zemin hazırlamaktadır.

## Sözlük

_Derste telafuz edilen anahtar kelimeler veya dikkate değer konular birer cümle ile özetlenir_

## Yardımcı Linkler

_Ders sırasında uğradığımız sayfalar varsa linkleri paylaşılır_

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# proje veya çözümü derlemek için
dotnet build

# çalıştırmak için
dotnet run
```

## Çalışma Zamanı

_Derste işlenen kodların çıktısı eklenir_

## Araştırsak iyi Olur

_Dersten sonra öğrencilerin araştırması için verilen konular buraya yazılır_

## Evde Çalışmak için Atıştırmalıklar

_Meraklısına evde çalışması için verilecek örnekler buraya yazılır_

## Kazanımlar

- Table, JSON, CSV, XML gibi temel veri saklama opsiyonlarını tanımak.
- CSV _(Comma-Seperated values)_ türünden dosya yazma, okuma işlemleri.
- Verileri JSON formatında serileştirmek.
- 
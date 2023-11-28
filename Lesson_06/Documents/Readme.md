# Lesson_06 : LINQ Metotlarının İç Dinamiklerini Anlamak

Genellikle belli bir domain için yazılmış olan dillere verilebilecek en güzel örnek SQL _(Structured Query Language)_ dilidir. SQL ile veri tabanlarında tutulan veriyi ingilizce diline son derece yakın cümeleler kurarak sorgulayabiliriz. Örneğin,

```sql
Select Id,Title,Status,Priority,Duration,Size from WorkItem 
where DurationType = 'Hour'
order by Duration,Size
```

bu cümle ile WorkItem tablosunda yer alan kayıtlardan saatlik olanları ilk önce süre sonrada işin büyüklüğüne göre sıralatarak listeletmekteyiz. Bu kolay yazım ifadesi çoğu zaman nesne yönelimli dillerde de arandı. C# tarafında buna benzer cümleleri LINQ desteklemekte ancak LINQ'in arkasında yatan dünyada çok önemli unsurlar. Bu dersteki amacımız LINQ olmadan nesne dizileri üzerinden bazı sorgulamaları nasıl yapabileceğimizi görmek, buradan hareketle çok basit anlamda temsilcilerin _(delegates)_ ne işe yaradığını anlamak, dolayısıyla LINQ'in temel yapı taşlarından olan genişletme metotlarına değinip örnek uygulamadaki problemleri LINQ sorguları ile değiştirmek olacaktır. Bu amaçla Lesson_06/Projects klasöründe yer alan Playground isimli konsol uygulaması üzerinden ilerlenecektir. Programda WorkItem türünden kobay nesneler barındıran generic bir List koleksiyonu kullanılmaktadır. Bu koleksiyon üstünde aşağıdakilere benzer sorguların yapılması planlanmıştır.

- Yüksek öncelikli işlerimizi listeyelim
- Saatlik işlerimizi listeleyelim
- Saatlik işlerimizin toplam süresini bulalım
- Önceliği normal olan işlerimizinde gün bazlı olanları listeleyelim
- Yüksek öncelikli işler için ayırdığımız sürelerin toplamını gün bazında hesap edelim
- En uzun başlıklı işimizi bulup ekrana yazdıralım

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

- Temel döngü enstrümanları ile nesne dizilerini sorgulamak
- Tekrarlı kod bloklarının önüne geçmek
- Temsilci _(Delegates)_ tipini temel seviyede tanımak
- Genişletme metotlarını _(Extension Methods)_ keşfetmek
- Daha fazla LINQ sorgusu yazabilmek
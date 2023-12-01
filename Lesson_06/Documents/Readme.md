# Lesson_06 : LINQ Metotlarının İç Dinamiklerini Anlamak

Genellikle belli bir domain için yazılmış olan dillere verilebilecek en güzel örnek SQL _(Structured Query Language)_ dilidir. SQL ile veritabanlarında tutulan veriyi İngilizce diline son derece yakın cümeleler kurarak sorgulayabiliriz. Örneğin,

```sql
Select Id,Title,Status,Priority,Duration,Size from WorkItem 
where DurationType = 'Hour'
order by Duration,Size
```

Bu cümle ile WorkItem tablosunda yer alan kayıtlardan saatlik olanları ilk önce süre sonrada işin büyüklüğüne göre sıralatarak listeletmekteyiz. Bu kolay yazım ifadesi çoğu zaman nesne yönelimli dillerde de arandı. C# tarafında buna benzer cümleleri LINQ _(Language INtegrated Query)_ desteklemekte ancak LINQ'in arkasında yatan dünyada çok önemli unsurlar var. 

Bu dersteki amacımız LINQ olmadan nesne dizileri üzerinden bazı sorgulamaları nasıl yapabileceğimizi görmek, buradan hareketle çok basit anlamda temsilcilerin _(delegates)_ ne işe yaradığını anlamak, dolayısıyla LINQ'in temel yapı taşlarından olan genişletme metotlarına _(Extension Methods)_ değinip örnek uygulamadaki problemleri LINQ sorguları ile değiştirmek olacaktır. Bu amaçla Lesson_06/Projects klasöründe yer alan Playground isimli konsol uygulaması üzerinden ilerlenecektir. Programda WorkItem türünden kobay nesneler barındıran generic bir List koleksiyonu kullanılmaktadır. Bu koleksiyon üstünde aşağıdaki maddelerdekine benzer sorguların yapılması planlanmıştır.

- Yüksek öncelikli işlerimizi listeyelim
- Saatlik işlerimizi listeleyelim
- Saatlik işlerimizin toplam süresini bulalım
- Önceliği normal olan işlerimizinde gün bazlı olanları listeleyelim
- Yüksek öncelikli işler için ayırdığımız sürelerin toplamını gün bazında hesap edelim
- En uzun başlıklı işimizi bulup ekrana yazdıralım

## Sözlük

- **Preprocessor Directives *(# ile başlayan ifadeler)* :** # işareti ile başlayan ön işlemci direktifi olarak geçen ifadelerdir. Özellikle derleme sırasında derleyiciye ön bilgilendirmede bulunup davranış değişikliklerine gidilmesini sağlayabilir. Mesela DEBUG isimli bir sembol _(symbol)_ tanımlanmışsa #if DEBUG...#endif bloğu sadece DEBUG sembolü aktifse çalıştırılacaktır. En çok kullanılan ön işlemci direktiflerinden birisi region...endregion bloklarıdır. Kod okunurluğunu artırır ancak yine de büyük kod bloklarından kaçınmak gerekir. Aski halde Cognitive Complexity değerleri yüksek kodlar oluşabilir. if, region gibi ön işlemci direktifleri dışında define, pragma, line, error gibi başka direktiflerde vardır. [Kısa detay için şu adreste bakabilirsiniz](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives)]
- **Delegate Tipi :** Bir metodu işaret edebilen tiplerdir. Bu sayede olaylar _(event)_ tanımlanabilir ve hatta metotlara parametre olarak fonksiyonlar taşınabilir. LINQ sorgularının çekirdeğini oluşturan genişletme metotlarında Func<T,TResult> isimli dahili delegate tipi sıklıkla kullanılır. Kendi delegate tiplerimizi tanımlayabilir ve böylece kendi tanımladığımı metot parametre yapılarına uyan fonksiyonları değişken olarak atayabilir, başka fonksiyonlara parametre olarak geçebilir veya bir aksiyon karşısında tetiklenen olay nesneleri ile ilişkilendirebiliriz.
- **Lambda Operatörü ( => ):** Delegate türünden değişkenler alan metot parametrelerinde sıklıkla kullanılır. Metoda parametre olarak bir kod bloğunun geçirilmesini sağlar. Örneğin Where genişletme metodunun parametresi Func<T,TResult> ve türevleri türündendir. Buna göre geriye TResult dönen ve parametre olarak T tipini alan metotları ifade eden kod bloklarını lambda operatörü ile işletici metotlara parametre olarak geçebiliriz.
- **Overload Method :** Aynı isimli yazılmış ama parametre yapıları farklı olan metotlar için kullanılan terimdir. Farklı parametrelerle farklı isimlerde n adet metot yazmak yerine aynı isimde olup farklı parametre imzaları içeren metotlar olarak düşünülebilir. Normal metotları overload edebileceğimiz gibi nesne örneklemelerinden kullanılan yapıcı metotları da _(constructor)_ farklı parametre deseneleri ile aşırı yükleyebiliriz.
- **Extension Method :** Var olan tipleri iç yapılarına müdahale etmeden genişletebilmemize imkan sağlayan enstrümanlardır. Bu var olan bir kod kütüphanesini değiştirmek zorunda kalmadan bu kütüphanedeki tiplerin fonksiyonel olarak genişletilebilmesi anlamına da gelir. Böylece asıl kütüphanenin yeninden derlenme ihtiyacı da ortadan kalkar. LINQ çekirdeğinde yer alan pek çok metot _(Select, Where, OrderBy, GroupBy, SingleOrDefault, Max, Sum vb)_ var olan IEnumerable gibi arayüz türevlerinin genişleticisi olan fonksiyonlardır.

## Yardımcı Linkler

- Derste gelen bir soru from ile başlayan LINQ sorgusunun SQL gibi veri tabanlarına yönlendirilip yönlendirilemeyeceği üzerine idi. Bu noktada ORM _(Object Relational Mapping)_ araçlarından ve Entity Framework' ten kısaca bahsettik. EF ile ilgili basit bir öğretiye [şu adresten](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli) bakabilirsiniz. Ayrıca daha fazla LINQ sorgusu yazmak isterseniz [bu adresten](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview) bilgi alabilirsiniz.

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# proje veya çözümü derlemek için
dotnet build

# çalıştırmak için
dotnet run
```

## Çalışma Zamanı

Programımızın son noktadaki çalışma zamanı çıktısı aşağıdaki gibidir.

![runtime.png](runtime.png)

## Araştırsak iyi Olur

Sonraki derslere hazırlık olması açısından delegate ile event enstrümanları arasındaki ilişki incelenebilir. Örneğin bir ürünün stok bilgisinin belli bir değerin altına düşmesi halinde sisteme bir olay fırlatılması vakasının çözümünde delegate ve event tiplerinin sıkı ilişkisi vardır. Delegate türü ile bir metot deseni ilişkilendirilirken event ile de delegate ilişkilendirilir. Tanımlanan event'e abone _(subscribe)_ olan bir başka nesne ise bu olayın gerçekleştiği durumları yakalayabilir. Böylece nesne kullanıcısı, stok değişikliği sonrası fırlayan bir olaya abone olduğu için onu yakalabilir ve bir aksiyon gerçekleştirebilir. Fırlatılan olay sonrası devreye girecek metodun deseni delegate tipi tarafından belirlenir. Bir sonraki derste bu konu ele alınacaktır ama ön hazırlık yapılması açısından delegate tipinin kullanımı ve event kavramı hakkında bilgi toplanmasında yarar vardır.

## Evde Çalışmak için Atıştırmalıklar

Bu derste işlenen örneğe benzer bir uygulama yazılıp üzerinden farklı LINQ sorgularının çalıştırılması denenebilir. Örnek olarak ürünleri temsil eden bir sınıf tasarlanabilir. Ürünün adını, kategorisini, birim fiyatını, güncel stok miktarını, satışta olup olmadığını tutan bir Product sınıfı tasarlanabilir. Sonrasında buna örnek veri seti hazırlanabilir. Veriyi In-Memory tutan bir program pratikler için kafidir. En az 10 ürün bilgisi girilip oluşturulan generic List koleksiyonu üstünde aşağıdaki sorgular denenebilir.

- Belli bir kategorideki ürünlerin listesinin bulunması
- Fiyatı belli bir limit aralığında olan ürünlerin fiyata göre artan sıradan listelenmesi
- Belli bir kategoride stok değeri belli bir değerin altında olan ürünlerin listelenmesi
- Satışta olmayan ürünlerin listelenmesi
- Satışta olan ve bellir bir kategorideki ürünlere %10 indirim uygulatılması

## Kazanımlar

- Temel döngü enstrümanları ile nesne dizilerini sorgulamak
- Tekrarlı kod bloklarının önüne geçmek
- Temsilci _(Delegates)_ tipini temel seviyede tanımak
- Genişletme metotlarını _(Extension Methods)_ keşfetmek
- Daha fazla LINQ sorgusu yazabilmek

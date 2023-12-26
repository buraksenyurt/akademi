# Lesson_10 : Interface Kavramına Giriş ve Nesne Bağımlılıklarının Çözümlenmesi

Bir önceki dersimizde Kanban borduna eklenen içeriklerin fiziki dosyaya comma-separated values (CSV) formatında yazılması için bir takım çalışmalar yapmıştık. Bu çalışmalar sırasında eklediğimiz kaydetme ve okuma metodları birim test projesindeki bazı testlerin Failed olarak hatalı sonlanmasına sebebiyet vermektedir. Bu dersteki amacımız söz konusu hatalara neden olan problemi görmek, bu probleme ait nesne bağımlılığını çözmek için de Interface türünü tanımaktır. Özellikle nesne yönelimli dillerin temel prensiplerinden olan kalıtım _(Inhertiance)_ ve çok biçimlilik _(Polymorphism)_ ilkelerinin C# tarafında uygulanmasında da önemli bir role sahip olan Interface türü nesne bağımlılıklarını tersine çevirerek loosely-coupled kullanımların tesis edilmesinde de kullanılmaktadır. Bu sayede birim testlerin çalışması için gereken birçok bağımlılık kolaylıkla mock'lanabilir hale gelmektedir. Interface türlerinin kullanımı sadece OOP açısından değil, test edilebilirlik, yüksek kalite kod, plug-in tabanlı ürünler geliştirilmesi açısından da önemlidir. Dersteki ana hedefimiz özellikle Load metodundaki ReadAllLines ile oluşan bağımlılığı metot dışına almak üzerine olacaktır.

## Sözlük

_Derste telafuz edilen anahtar kelimeler veya dikkate değer konular birer cümle ile özetlenir_

## Yardımcı Linkler

_Ders sırasında uğradığımız sayfalar varsa linkleri paylaşılır_

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# proje veya çözümü derlemek için
dotnet build

# projedeki testleri koşturmak için
dotnet test

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

- Nesne bağımlılıklarını çözümlemek için interface türünden yararlanılması.
- Interface türü ile çok biçimlilik ilkesinin uygulanması.
  
# Lesson_04 : _İşlenen Konuları Özetleyen Bir Başlık Gelir_

_Derste işlenen konularla ilgili özet bilgi gelir_

## Sözlük

- sln : Bir .net solution dosyasıdır. Solution dosyaları içerisinde birden fazla proje yer alabilir. Bu projeler sln dosyası içerisinde de bildirilir.
- csproj : Bir .net projesine ait bilgiler içeren dosyadır. Örneğin projenin referans ettiği diğer kütüphaneler veya nuget paketlerinin bildirimleri, .net framework sürümü, null değer kullanılıp kullanılmayacağı vb bilgiler bu dosya içerisinde yer alır.
- POCO(Plain Old CLR Objects) : Sadece property/field barındıran herhangi bir işlevsellik içermeyen sınıflardır.
- Birim Test(Unit Test): Yazdığımı metotların belirli kriterlere göre doğru şekilde çalıştığından emin olmak için kabul kriterlerine istinaden test metotlarının yazılması gerekir. Test metotları birim test olarak da bilinir.

## Yardımcı Linkler

- VS Code tarafında .net projeleri ile çalışırken yardımcı olacak bir eklenti -> https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit 
- .Net eko sisteminin paket yönetim hizmeti Nuget'tir -> https://www.nuget.org/ Bir çok konuda çözüm sunan paketlere nuget repolarından erişebilir ve projelerde kullanabiliriz.

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# dotnet ile oluşturabileceğimiz proje listesini görmek için
dotnet new list

# yeni bir class library açmak için
dotnet new classlib -o Entity

# projeyi solutiona'a eklemek için
dotnet sln add Entity/Entity.csproj

# bu dersteki console uygulamasını oluşturmak için
dotnet new console -o KanbanApp

# Proje klasöründeyken Entity projesini referans edebiliriz
cd KanbanApp
dotnet add reference ../../../Entity/Entity.csproj

# Console projesini solution'a eklemek içinse solution klasöründeyken
dotnet sln add Lesson_04/Projects/KanbanApp/KanbanApp.csproj

# Kanban operasyonlarını barındıracak class library projesini açmak için
dotnet new classlib -o Kanban.Data
# Kanban.Data projesini solution'a eklemek için
dotnet sln add Kanban.Data/Kanban.Data.csproj
# Kanban.Data projesi, Entity projesi içindeki tipleri de kullanacağından
# Kanban.Data projesine Entity projesini referans etmek gerekir.
cd Kanban.Data
dotnet add reference ../Entity/Entity.csproj

# xunit şablonunda test projesi açmak için
dotnet new xunit -o Kanban.Data.Tests

# test projesinin solution'a eklenmesi
dotnet sln add Kanban.Data.Tests/Kanban.Data.Tests.csproj

# test projesine gerekli diğer projelerin referans edilmesi
dotnet add reference ../Kanban.Data/Kanban.Data.csproj
dotnet add reference ../Entity/Entity.csproj

# proje veya çözümü derlemek için
dotnet build

# çalıştırmak için
dotnet run
```

## Çalışma Zamanı

_Derste işlenen kodların çıktısı eklenir_

## Araştırsak iyi Olur

- TDD (Test Driven Development) yaklaşımı geliştirilecere nasıl avantajlar sağlar, dezavantajları var mıdır, araştıralım. TDD kaynaklarda Red Green Blue development olarak da geçer. Önce kodun hata alarak yazılması sağlanır, sonra hata düzeltilerek doğru çalışması gerçeklenir. Son aşamada da kod refactor edilir yani iyileştirilir.
- Code Coverage nedir neden önemlidir araştıralım.

## Evde Çalışmak için Atıştırmalıklar

- Fibonacci sayı dizisini yazdıran bir metot ve bu metodun birim testini içeren bir proje geliştirebilirsiniz. Fibonacci serisi 0, 1, 1, 2, 3, 5, 8, 13, 21 şeklinde ilerleyen sayı dizisidir. Metodunuz belirli sayı kadar seriyi yazdıracak şekilde tasarlanmalı. Yani 50 değerini verirsek Fibonacci serisinin ilk 50 sayısını yazdırmalı. Test metodu da yazılacağından geriye n tane Fibonacci sayısını içeren bir dizi döndüren metot yazarsanız doğru bir yaklaşım olacaktır.

## Kazanımlar

_Ders konularından edinilmesi beklenen kazanımlar maddeler halinde listelenir_
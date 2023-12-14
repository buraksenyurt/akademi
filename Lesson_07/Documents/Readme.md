# Lesson_07 : Genişletme Metotları ve Event Kullanımı

Derste iki konuyu basit şekilde ele almaya çalıştık. İlki önceki dersten öğrendiğimiz delegate tipinin event nesneleri ile kullanılması. İkincisi ise yine LINQ _(Language INtegrated Query)_ sorgulama metotlarından aşina olduğumuz genişletme metotları _(Extension Methods)_

Genişletme metotları sayesinde var olan önceden tanımlanmış tiplere, içeriklerini değiştirmeye gerek kalmadan yeni fonksiyonellikler kazandırabiliriz. Örneğin Int32 tipine IsLessThan, IsGreaterThan veya String türüne WriteLovely gibi normalde built-in olarak gelmeyen yeni işlevsellikleri, genişletme metotları ile tesis edebiliriz. Bu, özellikle projelerde referans alarak kullandığımız harici kütüphanelere yeni fonksiyonellikler kazandırmak açısından da önemli bir enstrümandır.

Bu derste işlediğimiz konulardan bir diğeri de delegate tipleri ile birlikte ele alınan event nesneleri. Nesnelere event alanları ekleyerek, belli aksiyonlar karşısında object user'ların farklı süreçleri işletmesi sağlanabilir. Örneğin stok bilgilerini tuttuğumuz bir nesne modelinde stok miktarının belli bir değerin altına inmesi bir olayla ilişkilendirilebilir. Ya da sistemimizde servislere gelen talepleri izleyen bir program giderek daha yavaş cevap üreten hizmetleri ele alan bir olayı kullanarak uyarı sistemlerini harekete geçirebilir, genel kesintileri önlemek için çeşitli tedbirleri işletebilir. 

Basit anlamda olaylar gerçekleştiğinde, kendileri ile ilişkilendirilen delegate tiplerinin işaret ettiği türden metotların çalıştırılması söz konusu olur. Bu metotlar nesne olayına abone olan enstrümanlar tarafından kullanılır.

## Yardımcı Linkler

- [C# 3.0: Derinlemesine Extension Method Kavramı](https://www.buraksenyurt.com/post/C-3-0-Derinlemesine-Extension-Method-Kavramc4b1-bsenyurt-com-dan)
- [Çerezlik Algoritmalar ve Extension Methodlar](https://www.buraksenyurt.com/post/Cerezlik-Algoritmalar-ve-Extension-Methodlar)
- [Temsilciler (Delegates) Kavramına Giriş](https://www.buraksenyurt.com/post/Temsilciler-(Delegates)-Kavram%C4%B1na-Giris-bsenyurt-com-dan)
- [C# Temelleri - Olayları(Events) Kavramak](https://www.buraksenyurt.com/post/C-Temelleri-Olaylar%C4%B1(Events)-Kavramak-bsenyurt-com-dan)

## Kullandığımız Komutlar

Ders boyunca terminalden yürüttüğümüz komutlar aşağıdaki gibidir.

```shell
# projelerimizi eklemek için
dotnet add console --use-program-main -o UsingEvents
dotnet add console --use-program-main -o UsingExtensions

# proje veya çözümü derlemek için
dotnet build

# çalıştırmak için
dotnet run

# testleri koşturmak için
dotnet test
```

## Araştırsak İyi Olur

- Genişletme metotlarını yazmak için static sınıflar ve yine statik metotlar tanımladık. Normal bir sınıf ile static tanımlı sınıflar arasındaki farklar öğrenilebilir. Benzer şekilde static tanımlanmış bir metot ile normal bir metot arasında nasıl farklar olduğuna bakılabilir. Örneğin eğitim boyunca sık kullandığımız WriteLine metodu, Console sınıfı içinde tanımlanmış statik bir metottur. Bunun nasıl bir avantajı olabilir? _(İpucu; WriteLine metodunu çağırmak için Console sınfına ait bir nesne örnekliyor muyuz bakınız)_

## Çalışma Zamanı

UsingExtensions ve UsingEvents isimli programlara ait çalışma zamanı görüntüleri aşağıdaki gibidir.

![runtime_1.png](runtime_1.png)

![runtime_2.png](runtime_2.png)

## Evde Çalışmak için Atıştırmalıklar

Bu dersteki fonksiyonları test etmek amacıyla bir birim test projesi oluşturup üzerinde farklı kabul kriterlerini deneyebiliriz.

**Not: Konuyla ilgili olarak Kanban.Extensions projesinde integer bir değeri TaskSize'a çeviren genişletme metodu eklenmiş ve testleri de Kanban.Extensions.Tests isimli projeye eklenmiştir. Çalışmanız sırasında bu projeyi de referans alabilirsiniz.**

## Kazanımlar

- Nesnelere event bildirimleri ile yeni işlevsellikler kazandırmak
- Static sınıflar ve statik metotların kullanımı
- Var olan tiplerin içeriğini değiştirmeden genişletme metotları ile zenginleştirebilmek
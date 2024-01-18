# ESOGU C# ile Programlama - Final Sınavı - 20 Soru - 75 Dakika

## 20 : WorkItem Çıktılarının Filtrelenmesi

Çalıştığınız şirketteki yazılım işleri ile ilgili olarak aşağıdaki örnek kategorilendirme ve iş listesi kullanılıyor. Bu kodun çalışma zamanı çıktısı şıklardan hangisidir?

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp;

namespace Question_20
{
    internal static class Program
    {
        static void Main()
        {
            var categories = new List<Category> {
                new Category{Id=1,Name="Code Quality Works"},
                new Category{Id=2,Name="CI/CD Design"},
                new Category{Id=3,Name="Development Phase"},
                new Category{Id=4,Name="Testing"},
            };
            categories[0].WorkItems = new List<WorkItem>
            {
                new WorkItem{Id=1001,Name="Apply metodunun Cognitive Complexity değerleri azaltılacak",IsCompleted=false,Category=categories[0] },
                new WorkItem{Id=1002,Name="Invoice sınıfındaki tekrarlı kod blokları azaltılacak",IsCompleted=true,Category=categories[0] },
                new WorkItem{Id=1003,Name="Façade katmanı kaldırılacak",IsCompleted=false,Category=categories[0] },
                new WorkItem{Id=1004,Name="Discount metodundaki güvenlik açığı giderilecek",IsCompleted=true,Category=categories[0] },
                new WorkItem{Id=1005,Name="String + operasyonları StringBuilder ile değiştirilecek",IsCompleted=true,Category=categories[0] },
            };

            var completedWorkItems = categories[0].WorkItems.Where(x => x.IsCompleted).ToList();
            foreach (var workItem in completedWorkItems)
            {
                Console.WriteLine($"{workItem.Name}");
            }
        }
    }
}

namespace TodoApp
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkItem> WorkItems { get; set; }
    }
    public class WorkItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public Category Category { get; set; }
    }
}
```

- [ ] **a -** 1 numaralı kategorideki **tamamlanmış** WorkItem nesnelerinin isimleri ekrana yazdırılır.
- [ ] **b -** 1 numaralı kategorideki **tamamlanmamış** WorkItem nesnelerinin isimleri ekrana yazdırılır.
- [ ] **c -** Tüm kategorilerdeki **tamamlanmış** WorkItem nesnelerinin isimleri ekrana yazdırılır.
- [ ] **d -** Where sorgusu hatalı olduğundan kod derlenmez.

## 21 - Nesne Örnekleme

Aşağıdaki satırlardan hangisi bir **Category** nesne örneğinin oluşturulmasını sağlar.

- [ ] **a -** category = new Category();
- [ ] **b -** let category = new Category();
- [ ] **c -** var category:Category;
- [ ] **d -** var category = new Category();

## 22 - Servise Gelen Onlarca Komutun İşletilmesi

Geliştirilmekte olan bir servis uygulamasında sisteme gelen komutların geldikleri sırada işletilmesi istenmektedir. Bu işlem gelen komutların sayısı belli bir değere ulaştığında yapılmalıdır. Yani havuzda n adet komut biriktiğinde bu komut kümesinin işletilmesi beklenmektedir. Sistem özellikleri ve performans kriterleri göz önüne alındığında komutların bellekte depolanması ve bunun için de bir koleksiyon türünden yararlanılması tavsiye edilmiştir. Bunun için aşağıdaki çözümlerden hangisini kullanmak daha doğrudur?

- [ ] **a -** LIFO ilkesine göre çalışan generic Stack koleksiyonunu kullanırım.
- [ ] **b -** FIFO ilkesine göre çalışan Queue koleksiyonunu kullanırım.
- [ ] **c -** Komutları integer türden ardışıl bir sayaç değeri ile ilişkilendirip generic Dictionary koleksiyonunda Key:Value çiftleri şeklinde tutarak ilerlerim.
- [ ] **d -** Komutları öncelikle fiziki bir dosyaya kaydeder, n adet komut geldikten sonra bu dosyayı ilk satırdan okutarak ilgili komutların işletilmesini sağlarım.

## 23 - Test Edilebilirlik

Aşağıdaki kod parçasında daire alanlarının hesaplanmasına ilişkin bir metot ve üç kabul kriteri yer almaktadır.

```csharp
using Mathician;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Question_23
{
    [TestClass]
    public class MathicianTest
    {
        [TestMethod]
        public void Should_Zero_R_Returns_Zero()
        {
            Fermat fermat = new Fermat();
            var actual = fermat.CalculateSquare(new Circle());
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Should_Any_Pozitive_Returns_Value()
        {
            Fermat fermat = new Fermat();
            var actual = fermat.CalculateSquare(new Circle { R = 1 });
            var expected = Math.PI;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Should_Any_Negative_Returns_Zero()
        {
            Fermat fermat = new Fermat();
            var actual = fermat.CalculateSquare(new Circle { R = -1 });
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}

namespace Mathician
{
    public class Fermat
    {
        public double CalculateSquare(Circle circle)
        {
            if (circle.R <= 0)
            {
                return 0;
            }
            return Math.PI * Math.Pow(circle.R, 2);
        }
    }

    public class Circle
    {
        public double R { get; set; }
    }
}
```

Buna göre aşağıdaki ifadelerden hangisi doğrudur?

- [ ] **a -** Her üç test **başarılı(Success)** olur.
- [ ] **b -** Testlerin hepsi **başarısız(Fail)** olur.
- [ ] **c -** Should_Any_Pozitive_Returns_Value testi **başarılı(Success)**, diğerleri **başarısız(Fail)** olur.
- [ ] **d -** Should_Any_Pozitive_Returns_Value testi **başarısız(Fail)**, diğerleri **başarılı(Success)** olur.

## 24 - Kod Kalite Standartları

C# ile yazılmış bir metodun yüksek kalitede olması ve teknik borca sebebiyet vermemesi için aşağıdaki kriterlerden hangilerini karşılaması gerekir?

**I   -** Birim testleri yazılmış olmalıdır.
**II  -** Kod karmaşıklığı yani **Cognitive Complexity** değeri olabildiğince düşük olmalıdır.
**III -** Bir metodun kod satır sayısı 25 satırdan az **olmamalıdır**.
**IV  -** Metot adları yapılan işi belirten bir fiil ile başlamalıdır.

- [ ] **a -** I ve II
- [ ] **b -** I, II ve III
- [ ] **c -** I, II ve IV
- [ ] **d -** Hepsi

## 25 - Anahtar Kelimeler

Aşağıdaki kod parçasında yapılan işlemi şıklardan hangisi anlatmaktadır?

```csharp
using System.Collections.Generic;
using System.Linq;

namespace Question_25
{
    internal static class Program
    {
        static void Main()
        {
            var keywords = new Queue<string>();
            var tokens = new string[] { "SELECT", "FROM", "WHERE", "*", "JOIN", "LIKE", "=" };
            var expression = "SELECT * FROM Products WHERE CategoryId = 32";
            var words = expression.Split(' ');

            foreach (var word in from word in words
                                 where tokens.Contains(word)
                                 select word)
            {
                keywords.Enqueue(word);
            }
        }
    }
}
```

- [ ] **a -** expression değişkeninde yer alan cümledeki her bir karakteri alıp tokens isimli dizideki kelimelerin baş harfleri ile karşılaştırır ve eşleşenleri FIFO ilkesine göre çalışan generic Queue koleksiyonunda toplar.
- [ ] **b -** expression değişkeninde yer alan cümleyi boşluk karakterine göre parçalayıp elde edilen kelimelerden tokens dizisinde bulunanları tespit edip, keywords isimli FIFO ilkesine göre çalışan generic Queue koleksiyonunda toplar.
- [ ] **c -** expression değişkeninde yer alan cümleyi boşluk karakterine göre parçalayıp elde edilen kelimelerden tokens dizisinde bulunanları tespit edip, keywords isimli LIFO ilkesine göre çalışan generic Queue koleksiyonunda toplar.
- [ ] **d -** expression değişkeninde yer alan cümleyi boşluk karakterine göre parçalayıp elde edilen kelimeleri keywords isimli LIFO ilkesine göre çalışan generic Queue koleksiyonunda toplar.

## 26 - Nesne Topluluklarında Sorgu Çalıştırmak

Tasarladığımız Product isimli sınıfta ürün adı, birim fiyatı, stok miktarı, kategorisi vb özellikler tutulmakta. Program, Product nesne örneklerinden oluşan büyük boyutlu bir koleksiyonun içeriğini de veritabanından doldurmaktadır. Buna göre aşağıdaki kod parçalarından hangisi **kitap kategorisindeki ürünleri fiyatlarına göre tersten sıralar.**.

- [ ] a -
  
```csharp
var products = GetProducts();
var queryResult = from p in products
                  where p.Category.CategoryId == 2
                  orderby p.UnitPrice descending
                  select p;
```

- [ ] b -

```csharp
var products = GetProducts();
var queryResult = from p in products
                  where p.Category.CategoryId == 2
                  orderby p.UnitPrice
                  select p;
```

- [ ] c -

```csharp
var products = GetProducts();
var queryResult = select p in products
                  where p.Category.CategoryId == 2
                  orderby p.UnitPrice;
```

- [ ] d -

```csharp
var products = GetProducts();
var queryResult = products.Where(p=>p.Category.CategoryId == 2);
```

## 27 Temsilciler (Delegates)

Temsilci tipi ile ilgili olarak aşağıdakilerden hangisi doğrudur?

I  . Temsilciler ile metodları başka metotlara parametre olarak taşıyabiliriz.
II . Built-In tanımlı temsilcilerden olan **Func < T,TResult >** T türünden parametre alan ve TResult türünden parametre döndüren generic bir temsilcidir.
III. Bir event tanımlanırken ne tür metotların çalıştırılabileceğini belirtmek için temsilci tipinden yararlanılır.
IV. Kendi generic delegate tiplerimizi tanımlayabiliriz.

- [ ] **a -** I ve II
- [ ] **b -** Sadece I
- [ ] **c -** I, II, III
- [ ] **d -** Hepsi

## 28 Oyuncu Puanı

Aşağıdaki kod parçasında basit bir Player sınıfı tanımlanmış ve ona ait nesne örneği üzerinde bir takım işlemler gerçekleştirilmiştir. Sizce bu program ne yapmaktadır?

```csharp
using System;

namespace Question_28
{
    static class Program
    {
        static void Main()
        {
            var jhonDoe = new Player
            {
                Id = 1,
                NickName = "Jhon Doe",
                Point = 100
            };
            jhonDoe.RewardPointReached += JhonDoe_RewardPointReached;

            for (int i = 0; i < 10; i++)
            {
                jhonDoe.Point += 100;
            }
        }

        private static void JhonDoe_RewardPointReached(RewardPointReachedEventArgs eventArgs)
        {
            Console.WriteLine($"Oyuncunun puanı {eventArgs.OldPoint} den {eventArgs.CurrentPoint}'e geçti ve ödüle hak kazandı");
        }
    }

    class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        private int _point;

        public int Point
        {
            get { return _point; }
            set
            {
                if (value > 800 && value < 901)
                {
                    RewardPointReachedEventArgs eventArgs = new RewardPointReachedEventArgs();
                    eventArgs.OldPoint = _point;
                    eventArgs.CurrentPoint = value;
                    RewardPointReached(eventArgs);
                }
                _point = value;
            }
        }

        public event RewardPointReachedEventHandler RewardPointReached;
    }

    public delegate void RewardPointReachedEventHandler(RewardPointReachedEventArgs eventArgs);

    public class RewardPointReachedEventArgs
    {
        public int OldPoint { get; set; }
        public int CurrentPoint { get; set; }
    }
}
```

- [ ] **a -** Oyuncunun puanının 100er birim artırır ve 1100 birime kadar sürdürür.Program derleme zamanı hatası alacağından çalışmaz.
- [ ] **b -** Program derleme zamanı hatası alacağından çalışmaz.
- [ ] **c -** Oyuncunun puanı 100er birim artar ve bu değer 800 ile 901 birim arasına denk gelirse bir event fırlatılır. Buna bağlı olarak da ödül kazanıldığına dair bir bilgilendirme yapılır.
- [ ] **d -** Oyuncu puanında herhangi bir değer güncellemesi yapıldığında otomatik olarak bir olay tetiklenir.

## 29 - Güzel Yazı

Bir console uygulamasında "Sınavda Başarılar" metnini ekrana S_ı_n_a_v_d_a_ _B_a_ş_a_r_ı_l_a_r_ formatında yazdırmak için **String** tipine **WriteLovely** isimli aşağıdaki genişletme metodu eklenmek isteniyor. Buna göre ....... ile görülen kısımlara sırasıyla şıklardaki hangi ifadeler gelmelidir.

```csharp
public .......... class StringExtensions
{
    public .......... string WriteLovely(this .......... expression, char seperator)
    {
        var result = string.Empty;
        foreach (var c in expression)
        {
            result += $"{c}{seperator}";
        }

        return result;
    }
}
```

- [ ] **a -** static, static ,string
- [ ] **b -** void, void, string
- [ ] **c -** static, void, string
- [ ] **d -** ...... olan kısımlara bir şey yazmaya gerek yoktur

## 30 - İstisna Yönetimi Hakkında (Exception Handling)

C# dilinde çalışma zamanında oluşabilecek istisnai hatalar için bir mekanizma mevcuttur. Bu mekanizma kod tarafında **try…catch…finally** blokları ile yönetilir. Buna göre aşağıdaki ifadelerden hangisi/hangileri doğrudur.

**I.**  Tüm istisna nesneleri **Exception** sınıfından türer.

**II.** **try** bloğunda kontrol altına alınan kod parçasında bir istisna oluşsa da oluşmasa da **finally** bloğu çalıştırılır.

**III.** **catch** bloklarında birden fazla **Exception** türü kontrol edilebilir. Bir başka deyişle alt alta n sayıda catch bloğu hazırlayıp farklı türden Exception durumlarını kontrol altına alabiliriz.

**IV.** Bir önceki maddeye bağlı olarak **catch** bloklarının sıralamasının önemli olduğunu ifade edebiliriz. En belirgin olan **Exception** türünden en genel kapsamlı **Exception** türüne doğru bir sırayla yazılmaları beklenir. _(Önce FileNotFoundException ardından Exception için catch bloğu yazmak gibi hayal edilebilir)_

- [ ] **a -** Sadece I
- [ ] **b -** I ve II
- [ ] **c -** I, II ve IV
- [ ] **d -** Hepsi doğrudur.

## 31 - Dosya İşlemleri

Aşağıdaki kod parçasını dikkatlice inceleyiniz. Bu program şıklardaki işlevlerden hangisini gerçekleştirir.

```csharp
using System.Text;

namespace Question_31;

class Program
{
    static void Main()
    {
        var targetFile = Path.Combine(Environment.CurrentDirectory, "Games.csv");
        var games = new List<Game>{
            new() {Id=1,Title="Command & Conquer Generals",Point=7.3},
            new() {Id=2,Title="Sensible Soccer",Point=6.5},
            new() {Id=3,Title="Incredable Machines",Point=9.1}
        };
        WriteToCsv(targetFile, games);
    }
    static void WriteToCsv<T>(string targetFile, List<T> sourceList)
        where T : class
    {
        StringBuilder builder = new();
        foreach (var instance in sourceList)
        {
            builder.AppendLine(instance.ToString());
        }
        File.WriteAllText(targetFile, builder.ToString());
    }
}

class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = "Unknown Name";
    public double Point { get; set; }
    public override string ToString()
    {
        return $"{Id}|{Title}|Point";
    }
}
```

- [ ] **a -** Program ortamda **Games.csv** dosyasını bulamayacağından **FileNotFoundException** istisnası üreterek sonlanır.
- [ ] **b -** Oyun bilgileri aralarına **|** işareti konularak satır satır **Games.csv** dosyası içerisine yazılır.
- [ ] **c -** Oyun bilgileri aralarına boşluk bırakılara satır satır **Games.csv** dosyası içerisine yazılır.
- [ ] **d -** Oyun bilgileri aralarına **|** işareti konulur ve tümü tek bir satır olarak **Games.csv** dosyası içerisine yazılır.

## 32 - Ne Yazıyor?

Aşağıda geliştirilmekte olan bir uygulamaya ait küçük bir kod parçası yer almaktadır.

```csharp
var targetPath = Path.Combine(Environment.CurrentDirectory, $"{fileName}.json");
var content = JsonSerializer.Serialize(source, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText(targetPath, content);
```

- [ ] **a -** source ile belirtilen nesne içeriğini binary formata dönüştürür ve dosya içerisine yazar.
- [ ] **b -** source ile belirtilen nesne içeriğini comma-separated value formatına çevirip ve dosya içerisine yazar.
- [ ] **c -** source ile belirtilen nesne içeriğini girintili olarak json formatına çevirir ve json uzantılı bir dosyaya yazar.
- [ ] **d -** WriteAllText metodu json formatı ile çalışmadığından kod derlenmez.

## 33 - Bu genişletme fonksiyonu ne yapıyor?

Aşağıdaki 32 bitlik tamsayılar için yazılmış bir genişletme fonksiyonu (Extension Methods) vardır.

```csharp
namespace GlobalExtensions;

public static class NumberExtensions{

    public static uint Apply(this uint number){
        uint result = 0;
        while (number > 0)
        {
            uint remainder = number % 10;
            result = (result * 10) + remainder;
            number /= 10;
        }
        return result;
    }
}
```

Sizce bu fonksiyon aşağıdaki şıklardan hangisini gerçekleştirir.

- [ ] **a -** 32 bitlik bir tamsayının rakamlarının 10 ile bölmeden kalanlarının toplamını hesaplar.
- [ ] **b -** 32 bitlik bir pozitif tamsayıyı tersine çevirip döndürür.
- [ ] **c -** 32 bitlik bir pozitif tamsayıyının basamakları toplamını döndürür.
- [ ] **d -** Sonsuz döngü durumu oluştuğundan metot herhangibir sonuç döndüremeyecektir.

## 34 - Nesne Bağımlılıkları

Yazmakta olduğumuz bir birim test fonksiyonu aşağıdaki kod parçasında görüldüğü gibidir.

```csharp
[Fact]
public void Get_TaskManager_InProgress_State_List_Test()
{
    TaskManager taskManager = new(new LoadFromDatabase());
    var actual = taskManager.GetTasks(TaskState.InProgress);
    Assert.True(actual.Count > 0);
}
```

Bu birim test metodu **InProgress** durumunda olan en az bir Task’ın olduğu durumu kontrol etmektedir. **TaskManager** sınıfı örneklenirken kullanılan **LoadFromDatabase** sınıfı, Task listesini bir veritabanından çekmektedir. Ancak test çalıştırıldığında söz konusu veritabanına **bağlanılamamakta** ve test **Failed** olarak sonlanmaktadır. Böyle bir senaryoda sizce aşağıdaki seçeneklerden hangisini uygulamak en ideal yaklaşımdır.

- [ ] **a -** Kullanılan veri tabanını kendi sistemime kurar(Local bilgisayara) ve testleri Local bilgisayar üstünden koştururum.
- [ ] **b -** LoadFromDatabase sınıfı yerine sistemde var olan LoadFromFile nesnesini kullanır ve task listesinin dosyadan okunmasını sağlarım.
- [ ] **c -**  Veri tabanı bağlantısını kontrol eder ve local bilgisayardan bağlanılamıyorsa testleri veri tabanının olduğu sunucu üzerinde çalıştırırm.
- [ ] **d -** Moq veya benzeri bir mocking kütüphanesi kullanır, sanki ihtiyaç duyulan veriler veritabanından geliyormuş gibi Fake nesne oluşturur, en az bir Task için State bilgisini InProgress’e çeker ve böylece veritabanına gitme ihtiyacından kurtulurum.

## 35 - Kalıtım (Inheritance)

Aşağıdaki geliştirilmekte olan bir oyun programına ait bir kod parçası yer almaktadır.

```csharp
public abstract class Character
{
    public string Name { get; set; }
    public int AttackPower { get; set; }
    public int Health { get; set; }
    public Character(int power, int health, string name)
    {
        AttackPower = power;
        Health = health;
        Name = name;
    }
    public void Defend(int damage)
    {
        Health -= damage;
    }
    public virtual void Attack(Character target)
    {
        target.Health -= AttackPower;
    }
    public abstract void Draw();
}

public class Mage
    : Character
{
    public int Mana { get; set; }
    public Mage(int power, int health, int mana, string name)
        : base(power, health, name)
    {
        Mana = mana;
    }
    public override void Attack(Character target)
    {
        if (Mana >= 7)
        {
            target.Health -= AttackPower * 2;
            Mana -= 7;
        }
        else
        {
            base.Attack(target);
        }
    }
    public override void Draw()
    {
        Console.WriteLine($"{Name} ekrana çizilir");
    }
}

public class Warrior
    : Character
{
    public int Armor { get; set; }
    public Weapon EquipedWeapon { get; set; }
    public Warrior(int power, int health, int armor, string name, Weapon weapon)
        : base(power, health, name)
    {
        Armor = armor;
        EquipedWeapon = weapon;
    }
    public override void Attack(Character target)
    {
        int totalDamage = AttackPower;
        if (EquipedWeapon != null)
        {
            totalDamage += EquipedWeapon.AdditionalDamage;
        }
        target.Health -= totalDamage;
    }
    public override void Draw()
    {
        Console.WriteLine($"{Name} ekrana çizilir");
    }
}
```

Bu kod parçası ile ilgili olarak aşağıdaki yorumlardan hangisi yanlıştır?

- [ ] **a -** abstract olarak tanımlanmış olan Character sınıfı doğrudan new operatörü ile örneklenemese de, kendisinden türeyen Mage ve Warrior nesne örneklerini taşıyabilir.
- [ ] **b -** Character sınıfı içerisinde yer alan Attack metodu virtual olarak tanımlanmıştır ve tüm türeyenler için varsayılan bir davranış sergilemektedir. Ancak virtual olması sebebiyle, istenirse türeyen sınıflarda ezilebilir.
- [ ] **c -** Character sınıfı içinde tanımlanmış olan abstract Draw metodu türeyen sınıflar tarafından tekrardan yazılmak _(ya da ezilmez-override)_ zorundadır.
- [ ] **d -** Mage ve Warrior sınıfları aşırı yüklenmiş yapıcı metotlara _(Default Constructor)_ sahip olsa da varsayılan yapıcı metod _(parametre almadan new ile çağrılan versiyon)_ kullanılarak da örneklenebilirler.

## 36 - Kalıtım (Inheritance) Kavramı

Kalıtım nesne yönelimli programlama dillerinin en önemli özelliklerinden birisidir. Sizce aşağıdaki ifadelerden hangisi veya hangileri doğrudur?

**I**   - C# tarafında bir sınıfın birden fazla sınıftan türemesi yasaktır. Ancak bir sınıf birden fazla Interface'i implemente edebilir ve bu şekilde çoklu kalıtım desteklenebilir.

**II**  - Kalıtım için C# tarafında kullanılan enstrümanlardan birisi olan abstract sınıflar tek başlarına örneklenemeyen _(new operatörü ile oluşturulamayan)_ ama kendisinden türeyen nesneleri taşıyabilen tiplerdir.

**III** - abstract sınıflar, interface türünün aksine iş yapan metotlar veya özellikler içerebilirler.

**IV**  - Interface türleri SOLID ilkelerinden Dependency Inversion kuralının uygulanarak nesne bağımlılıklarının tersine çevrilmesinde kullanılabilirler.

- [ ] **a -** Sadece I ve II doğrudur.
- [ ] **b -** I, II ve IV doğrudur.
- [ ] **c -** III ve IV doğrudur.
- [ ] **d -** Hepsi doğrudur.

## 37 - Nasıl bir yol izlersin? (Yorumsal)

Geliştirmekte olduğun bir oyun programında tasarladığın nesnelerin ortak ve farklı davranışları söz konusu. Bazı oyun nesneleri hareket edebilirken _(Warrior, Archer, Battleship vb)_ bazıları yerleştirildikleri konumda hareketsiz duran türden _(FarmHouse, Castle, Bunker)_ . Bazıları hem hareket edip hem ateş ederken _(Tank, Warrior, Archer, Battleship vb)_ bazıları sabit olup ama ateş edebilen _(Bunker, Artillery)_ türden. Hatta hareket edebilen nesnelerin hareket biçimleri de birbirlerinden farklı. Bazıları sadece karada giderken _(Tank, Warriro vb)_ bazıları havada _(Plane, Bomber)_ bazıları denizde _(Battleship, Submarine)_ gidiyor. Bazıları da amfibik özellikler gösteriyor. Örneğin hem karada hem denizde giden türden _(Hovercraft)_ oyun nesneleri de söz konusu. Dolayısıyıla uygulamada anahtar noktalardan birisi nesne davranışlarının doğru bir şekilde tasarlanması. Öyle bir yol izlenmeli ki türlerin sahip olması gereken davranışlar o türlere mutlaka uygulansınlar ve bir tür birden fazla davranışı da sağlayabilsin. Nasıl bir yol izlersiniz, birkaç cümle ile yorumlayınız.

```Text




```

## 38 - Çıktı ne olur?

Aşağıdaki kod parçasını göz önüne alalım.

```csharp
using Question_38;

var animal = new Cat();
Console.WriteLine($"{animal.Speak()}");

namespace Question_38
{
    class Animal
    {
        public virtual string Speak()
        {
            return "Generic animal sound";
        }
    }
    class Cat : Animal
    {
        public override string Speak()
        {
            return "Miaw";
        }
    }
}
```

Bu kodun çalışması ile ilgili aşağıdaki şıklardan hangisi doğrudur?

- [ ] **a -** Animal sınıfındaki Speak metodu çalışır.
- [ ] **b -** Cat sınıfındaki Speak metodu çalışır.
- [ ] **c -** Önce Cat sınıfındaki Speak metodu, ardından Animal sınıfındaki Speak metodu çalışır.
- [ ] **d -** Cat sınıfında Animal sınıfındaki Speak metodu yazılamayacağından derleme zamanı hatası _(Compile Time Error)_ alınır.

## 39 - Interface ve Nesne Bağımlılıkları

Aşağıda verilen kod parçasını göz önüne alalım.

```csharp
using ServiceLib;

var client = new ConsoleClient(new CategoryMockService());
var products = client.GetProductsByCategory(1);
foreach (var product in products)
{
    Console.WriteLine($"{product.Id}, {product.Name}, {product.ListPrice}");
}

namespace ServiceLib
{
    public class ConsoleClient
    {
        private readonly IService<List<Product>> _categoryService;
        public ConsoleClient(IService<List<Product>> categoryService)
        {
            _categoryService = categoryService;
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            var response = _categoryService.Send(new Request { Id = categoryId });
            return response.Result;
        }
    }

    public interface IService<T>
        where T : class, new()
    {
        Response<T> Send(Request request);
    }

    public class CategoryMockService
        : IService<List<Product>>
    {
        Response<List<Product>> IService<List<Product>>.Send(Request request)
        {
            return new Response<List<Product>>
            {
                Result = new List<Product>() {
                    new() { Id = 1, Name = "CPU 1 Ghz", ListPrice = 199.60M }
                    , new() { Id = 2, Name = "VGA Adapter", ListPrice = 9.55M }
                },
                IsSuccess = true
            };
        }
    }
}
```

Buna göre aşağıdaki şıklardan hangisi doğrudur?

- [ ] **a -** ConsoleClient sınıfına yapıcı metodu aracılığıyla IService bağımlılığı enjekte edilir.
- [ ] **b -** ConsoleClient sınıfı ile CategoryMockService sınıfı birbirlerine sıkı sıkıya bağlıdır _(Tightly Coupling)_
- [ ] **c -** Örnek kod, Dependency Injection ile ilgili bir uyarlama içermez.
- [ ] **d -** IService arayüzünün CategoryMockService uyarlaması hatalı olduğundan kod derlenmez.

## 40 - Kod Yorumlamak

Aşağıda bir console uygulamasına ait kod parçası yer almaktadır.

```csharp
int hiddenNumber = new Random().Next(1, 51); // Produce a random number between 1 and 51
int number = 0;
int totalAttempt = 0;
const int maxTries = 5;

while (number != hiddenNumber)
{
    if (totalAttempt >= maxTries)
    {
        Console.WriteLine($"Game over! My secret ise {hiddenNumber}");
        break;
    }

    totalAttempt++;
    Console.Write("Attempt " + totalAttempt + ": ");
    var userInput = Console.ReadLine();

    if (!int.TryParse(userInput, out number))
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    if (number < hiddenNumber)
        Console.WriteLine("Too low. Try again.");
    else if (number > hiddenNumber)
        Console.WriteLine("Too high. Try again.");
    else
    {
        Console.WriteLine($"Congratulations! You did it in {totalAttempt} attempts.");
        break;
    }
}
```

Kodun ne yaptığını, adımlarını, önemli noktalarını 256 kelimeyi geçmeyecek şekilde anlatınız?

```text

```

### Cevap Anahtarı

Toplamda 120 puanlık soru söz konusudur. Bilerek 20 puan fazladan yer almaktadır. Ders seçmeli olduğundan öğrencilere bir jest olarak düşünülebilir :D

| Soru 	| Cevap  | Puan   |
|------	|--------|--------|
|  20   |   A  	 |    3	  | 
|  21   |   D  	 |    3	  | 
|  22   |   B 	 |    5	  | 
|  23   |   A  	 |    5	  | 
|  24   |   C  	 |    5	  | 
|  25   |   B  	 |    8	  | 
|  26   |   A  	 |    5	  | 
|  27   |   D  	 |    3	  | 
|  28   |   C  	 |    8	  | 
|  29   |   A  	 |    5	  | 
|  30   |   D  	 |    5   | 
|  31   |   B  	 |    8	  | 
|  32   |   C  	 |    3	  | 
|  33   |   B  	 |    8	  | 
|  34   |   D  	 |    8	  | 
|  35   |   D  	 |    8   | 
|  36   |   D  	 |    8	  | 
|  37   | Yorum  | Max 20 | 
|  38   |   B  	 |    5	  | 
|  39   |   A  	 |    7	  | 
|  40   | Yorum  | Max 15 |

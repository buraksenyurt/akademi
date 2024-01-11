using Deppo;
using Cache;
using Database;
using DataContext;

Dictionary<int, string> colorCodes = new Dictionary<int, string>();
colorCodes.Add(0, "BLACK");
colorCodes.Add(1, "RED");
colorCodes.Add(2, "BLUE");
colorCodes.Add(3, "GREEN");
Console.WriteLine($"{colorCodes[1]},{colorCodes[2]},{colorCodes[3]}");

var cacheManager = new CacheService<Announcment>(); // CacheService sınıfının T kullanan üyeleri Announcment tipi ile çalışacaktır
var anno1 = new Announcment
{
    Id = 1,
    Title = "The Matriks",
    Content = @"
            <html>
                <title>The Matriks I</title>
                <body>
                    <div>
                        Some thoughts...
                    </div>
                </body>
            </html>
            "
};

var baldersGate = new Announcment
{
    Id = 2,
    Title = "PreSales for Balder's Gate",
    Content = @"
            <html>
                <title>PreSales for Balder's Gate</title>                
                <body>
                    <div>
                        <h2>Balder's Gate Game/<h2>
                        Some thoughts...
                    </div>
                </body>
            </html>
            "
};

cacheManager.Set("MatriksAnno", anno1);
var cached = cacheManager.Get("MatriksAnno");
Console.WriteLine(cached.Title);

cacheManager.Set("BaldersGate", baldersGate);
cached = cacheManager.Get("BaldersGate");
Console.WriteLine(cached.Title);

// Bir başka generic tür kullanımı
var repository = new Repository<Announcment>();
repository.Add(anno1);
var anno2 = repository.Get(1);
Console.WriteLine(anno2.Title);

var ctgryRepository = new Repository<Category>();
ctgryRepository.Add(new Category { Id = 1, Title = "Books" });
var ctgry = ctgryRepository.Get(1);
Console.WriteLine(ctgry.Title);

var johnDoe = new Player { Id = 1, Name = "Johny Doey", Point = 7.56 };
var middleLittle = new Player { Id = 2, Name = "Middle Little", Point = 5.52 };
var calculator = new SmartCalc<Player, double>();

var teamPoint = calculator.Sum(johnDoe, middleLittle);
Console.WriteLine($"Total team point {teamPoint}");

// var bookCategory = new Category { Id = 1, Title = "Books" };
// var lpCategory = new Category { Id = 2, Title = "Longplay" };
// var total = bookCategory + lpCategory;
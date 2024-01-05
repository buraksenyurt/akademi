using GameLib;

Warrior bran = new(5, 100, 25, "Bran Ironfist", new Weapon(WeaponType.Sword, 5));
Mage tirinity = new(7, 150, 1, "Tirinity");
Healer healer = new(1, 100, 1, "Gorath Arcanefury");

tirinity.Attack(bran);

Console.WriteLine($"{tirinity.Name}, {bran.Name}'e saldırdı. {bran.Name} in şu anki sağlık durumu, {bran.Health}");

tirinity.Mana = 10;
tirinity.Attack(bran);
Console.WriteLine($"{tirinity.Name} dolan mana gücü ile tekrar saldırdı. {bran.Name}'in şimdiki sağlık durumu, {bran.Health}");
healer.Heal(bran, 5);
Console.WriteLine($"{healer.Name}, {bran.Name} 'i iyileştirdi. Şimdi {bran.Name} in gücü, {bran.Health}");

bran.Attack(tirinity);
Console.WriteLine($"{bran.Name} kılıcı ile {tirinity.Name}'e saldırdı. {tirinity.Name} şimdiki sağlık durumu, {tirinity.Health}");

var mordor = new GameSchene(80, 60);
mordor.AddCharacter(new Healer(1, 75, 1, "Aelthas Sunweaver"), 0, 0);
mordor.AddCharacter(tirinity, 3, 5);
mordor.AddCharacter(bran, 6, 7);
mordor.AddCharacter(new Villager(5, 10, "Eldin Barleydrew"), 10, 10);
mordor.AddCharacter(new Villager(5, 10, "Mira Meadowfield"), 11, 10);
mordor.AddCharacter(new Villager(5, 10, "Tobas Greenhand"), 12, 10);
mordor.Draw();

// Bir Character nesnesini aşağıdaki gibi oluşturmanın program açısından bir anlamı yoktur.
// Bundan dolayı Character sınıfı abstract sınıf olarak da tasarlanabilir
// abstract sınıflar new operatörü ile örneklenemezler ve bu nedenle aşağıdaki gibi kullanılamazlar
// var anonymous = new Character(10, 100);
// ancak Character sınıfı abstract olsa da kendisinden türeyen nesnelerin örneklerini taşıyabilir
var character = tirinity;
character.Attack(bran); // yine Trinity sınıfındaki Attack metodu çalışır
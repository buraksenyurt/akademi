namespace Exercise;
static class Program
{
    static void Main()
    {
        var products = GetProducts();
        // Örnek Sorgu; 2 numaralı Kitap kategorisindeki ürünleri fiyatlarına göre tersten sıralama
        var queryResult = from p in products
                          where p.Category.CategoryId == 2
                          orderby p.UnitPrice descending
                          select p;
        foreach (var product in queryResult)
        {
            Console.WriteLine($"{product.Name} ({product.UnitPrice})");
        }

        //TODO@Everyone Antrenman Soruları

        // Stok değeri 10un altında olan ürünleri kategori adları ile birlikte listeleyin

        // Kategorileri sahip oldukları ürün sayıların göre gruplayarak listeleyin (GroupBy,Sum kullanımlarına bakılmalı)

        // Satışta olmayan ürünlerin toplam birim fiyatını bulun

        // A harfi ile başlayan ürünleri listeleyin

        // A harfi ile başlayan ürünleri kategorilerine göre gruplayıp kaçar adet olduklarını listeleyin

        // Belli bir kategoride ve belli bir fiyat aralığındaki ürünlerin listesini döndüren bir metot hazırlayın
    }

    static List<Product> GetProducts()
    {
        // !!! Category ve Product listelerindeki örnekler ChatGPT'ye hazırlatılmıştır

        var recordCategory = new Category { CategoryId = 1, Name = "Vinyl Records" };
        var fictionBookCategory = new Category { CategoryId = 2, Name = "Science Fiction Books" };
        var graphicCardCategory = new Category { CategoryId = 3, Name = "Graphics Cards" };
        var cpuCategory = new Category { CategoryId = 4, Name = "Processors" };
        var officeSuppliesCategory = new Category { CategoryId = 5, Name = "Office Supplies" };
        var candiesCategory = new Category { CategoryId = 6, Name = "Candies" };
        var camerasCategory = new Category { CategoryId = 7, Name = "Cameras" };

        var list = new List<Product>();

        list.AddRange(new List<Product>
            {
                new() { ProductId = 1, Name = "Abbey Road - The Beatles", UnitPrice = 29.99m, StockQuantity = 25, OnSale = false, Category = recordCategory  },
                new Product { ProductId = 2, Name = "Moonlight Sonata - Beethoven", UnitPrice = 22.50m, StockQuantity = 30, OnSale = false, Category = recordCategory },
                new Product { ProductId = 3, Name = "The Nutcracker Suite - Tchaikovsky", UnitPrice = 24.75m, StockQuantity = 20, OnSale = true, Category = recordCategory },
                new Product { ProductId = 4, Name = "Kind of Blue - Miles Davis", UnitPrice = 27.99m, StockQuantity = 15, OnSale = true, Category = recordCategory },
                new Product { ProductId = 5, Name = "The Wall - Pink Floyd", UnitPrice = 32.50m, StockQuantity = 18, OnSale = true, Category = recordCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 6, Name = "Dune - Frank Herbert", UnitPrice = 18.99m, StockQuantity = 40, OnSale = true, Category = fictionBookCategory  },
                new Product { ProductId = 7, Name = "Neuromancer - William Gibson", UnitPrice = 15.25m, StockQuantity = 35, OnSale = true, Category = fictionBookCategory },
                new Product { ProductId = 8, Name = "Ender's Game - Orson Scott Card", UnitPrice = 20.50m, StockQuantity = 25, OnSale = true, Category = fictionBookCategory },
                new Product { ProductId = 9, Name = "The Hitchhiker's Guide to the Galaxy - Douglas Adams", UnitPrice = 14.99m, StockQuantity = 30, OnSale = true, Category = fictionBookCategory },
                new Product { ProductId = 10, Name = "Foundation - Isaac Asimov", UnitPrice = 19.75m, StockQuantity = 22, OnSale = true, Category = fictionBookCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 11, Name = "NVIDIA GeForce RTX 3080", UnitPrice = 699.99m, StockQuantity = 15, OnSale = true, Category = graphicCardCategory },
                new Product { ProductId = 12, Name = "AMD Radeon RX 6800 XT", UnitPrice = 649.95m, StockQuantity = 20, OnSale = true, Category = graphicCardCategory },
                new Product { ProductId = 13, Name = "NVIDIA Quadro P5000", UnitPrice = 899.50m, StockQuantity = 10, OnSale = true, Category = graphicCardCategory },
                new Product { ProductId = 14, Name = "Gigabyte GeForce GTX 1660 Super", UnitPrice = 299.75m, StockQuantity = 18, OnSale = false, Category = graphicCardCategory },
                new Product { ProductId = 15, Name = "MSI Radeon RX 6700 XT", UnitPrice = 579.50m, StockQuantity = 25, OnSale = false, Category = graphicCardCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 16, Name = "Intel Core i9-9900K", UnitPrice = 449.99m, StockQuantity = 25, OnSale = true, Category = cpuCategory },
                new Product { ProductId = 17, Name = "AMD Ryzen 7 5800X", UnitPrice = 399.75m, StockQuantity = 15, OnSale = false, Category = cpuCategory },
                new Product { ProductId = 18, Name = "Apple M1 Chip", UnitPrice = 599.50m, StockQuantity = 30, OnSale = false, Category = cpuCategory },
                new Product { ProductId = 19, Name = "Intel Core i5-11600K", UnitPrice = 269.99m, StockQuantity = 20, OnSale = true, Category = cpuCategory },
                new Product { ProductId = 20, Name = "AMD Ryzen 9 5950X", UnitPrice = 799.00m, StockQuantity = 12, OnSale = true, Category = cpuCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 21, Name = "Double A A4 Paper (500 Sheets)", UnitPrice = 5.99m, StockQuantity = 100, OnSale = true, Category =  officeSuppliesCategory},
                new Product { ProductId = 22, Name = "HP Printing Paper A4 (Ream)", UnitPrice = 8.25m, StockQuantity = 80, OnSale = true, Category = officeSuppliesCategory },
                new Product { ProductId = 23, Name = "Navigator A4 Universal Paper", UnitPrice = 6.50m, StockQuantity = 120, OnSale = false, Category = officeSuppliesCategory },
                new Product { ProductId = 24, Name = "Canon Office A4 Paper", UnitPrice = 7.75m, StockQuantity = 90, OnSale = true, Category = officeSuppliesCategory },
                new Product { ProductId = 25, Name = "Xerox Performer A4 Paper", UnitPrice = 5.50m, StockQuantity = 110, OnSale = true, Category = officeSuppliesCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 26, Name = "Gummy Bears", UnitPrice = 2.99m, StockQuantity = 50, OnSale = false, Category = candiesCategory },
                new Product { ProductId = 27, Name = "Chocolate Bar", UnitPrice = 1.75m, StockQuantity = 40, OnSale = true, Category = candiesCategory },
                new Product { ProductId = 28, Name = "Lollipop Assortment", UnitPrice = 3.50m, StockQuantity = 30, OnSale = true, Category = candiesCategory },
                new Product { ProductId = 29, Name = "Sour Candy Strips", UnitPrice = 2.25m, StockQuantity = 45, OnSale = true, Category = candiesCategory },
                new Product { ProductId = 30, Name = "Jelly Beans Mix", UnitPrice = 4.00m, StockQuantity = 35, OnSale = false, Category = candiesCategory }
            });

        list.AddRange(new List<Product>
            {
                new Product { ProductId = 31, Name = "Canon EOS 5D Mark IV", UnitPrice = 2499.99m, StockQuantity = 10, OnSale = true, Category = camerasCategory },
                new Product { ProductId = 32, Name = "Nikon D850", UnitPrice = 2799.95m, StockQuantity = 8, OnSale = true, Category = camerasCategory },
                new Product { ProductId = 33, Name = "Sony Alpha a7 III", UnitPrice = 1999.50m, StockQuantity = 12, OnSale = true, Category = camerasCategory }
            });

        return list;
    }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public bool OnSale { get; set; }
    public Category Category { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
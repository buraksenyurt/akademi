using Database;

namespace DataContext;

public interface IRepository<T>
    where T : class, IEntity
{
    void Add(T entity);
    T Get(int id);
    IEnumerable<T> Get();
}

public class Repository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly List<T> _items = new();
    public void Add(T entity)
    {
        _items.Add(entity);
    }

    public T Get(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public IEnumerable<T> Get()
    {
        return _items;
    }
}

public class Category
    : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = "NoName";
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
    
    public static int operator +(Category a, Category b)
    {
        return a.Products.Count() + b.Products.Count();
    }
}

public class Product
    : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "NoName";
    public string code { get; set; }
    public double ListPrice { get; set; }
    public Category Category { get; set; }
}
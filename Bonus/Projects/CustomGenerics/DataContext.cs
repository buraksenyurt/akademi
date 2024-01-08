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
        // Assume each T has an Id property (not implemented here)
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public IEnumerable<T> Get()
    {
        return _items;
    }
}
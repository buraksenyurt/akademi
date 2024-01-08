using Database;

namespace Cache;
/*
    Aşağıda örnek bir geliştirici tanımlı generic sınıf şablonu yer almaktadır.
    Sınıfın içerisindeki _cache alanı aslında key:value çiftleri tutan bir Dictionarykoleksiyonudur.
    Bu koleksiyonun ilk parametresi sabit ve String türündendir.
    Value değerleri ise T tipindendir.
    Dolayısıyla CacheService sınıfına ait bir nesneyi örneklerken hangi tipler için 
    caching özelliklerini kullanacağını T ile belirtebiliriz.

*/
public class CacheService<T>
    where T : IEntity, new() // generic T tipinin default constructor'a sahip olması ve IEntity arayüzünü uyarlaması beklenmektedir. (Generic Constraint)
{
    // T görülen yerlere CacheService' in örneklendiği yerde hangi tip verilmişse o tipe ait nesne örnekleri gelir
    private readonly Dictionary<string, T> _cache = new();
    /*
        Aşağıdaki kullanımlarda olduğu gibi generic tipler metot parametresi olabilir, metotlardan döndürülebilir.
    */
    public T Get(string key)
    {
        if (_cache.ContainsKey(key))
        {
            return _cache[key];
        }
        return default;
    }

    public void Set(string key, T value)
    {
        _cache[key] = value;
    }
}
namespace Deppo;

/*
    Burada farklı bir uygulama şekli söz konusudur. SmartCalc isimli generic sınıf içerisinde T tipi üstünden 
    toplama, çarpma, bölme, çıkarma gibi matematiksel işlemler yapılmaktadır. 
    Bu toplama işleminin sonucu da R türünden bir değer olacaktır.

    Bu sebepten T tipinin +, -, *, /, gibi operatörleri uygulayabiliyor (overload) olması gerekir.
    Bunu sağlamak içinse ICalculable<T,R> gibi bir arayüz (interface) hazırlanır.
    T tipi için SmartCalc sınıfına eklenen generic constraint, söz konusu T tipinde bu operatörlerin yüklenmesi ve 
    R türünden dönüşler yapılması şartını koşar.
    Aksi durumda derleme zamanında aşağıdaki hatayı verir.
    Operator '+' cannot be applied to operands of type 'T' and 'T' (CS0019)

*/

public interface ICalculable<T, R>
    where T : ICalculable<T, R>
{
    public abstract static R operator +(T left, T right);
    public abstract static R operator -(T left, T right);
}
public class SmartCalc<T, R>
    where T : ICalculable<T, R>
{
    public R Sum(T x, T y)
    {
        return x + y;
    }
    public R Dif(T x, T y)
    {
        return x - y;
    }
}

public class Product
    : ICalculable<Product, int>
{
    public int ProductId { get; set; }
    public required string Title { get; set; }
    public int Quantity { get; set; }

    public static int operator +(Product left, Product right)
    {
        return left.Quantity + right.Quantity;
    }

    public static int operator -(Product left, Product right)
    {
        return left.Quantity - right.Quantity;
    }
}

public class Player
    : ICalculable<Player, double>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Point { get; set; }

    public static double operator +(Player left, Player right)
    {
        return left.Point + right.Point;
    }

    public static double operator -(Player left, Player right)
    {
        return left.Point - right.Point;
    }
}
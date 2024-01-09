/*
    Sistem içinde tanımlı Attribute tipleri gibi kendi niteliklerimizi de geliştirebiliriz.

    Bir nitelik uygulandığı tiple ilgili olarak çalışma zamanına ekstra bilgiler taşıyabilir. 
    Çalışma zamanları IDE'ler, Service Host mekanizmaları gibi çeşitli uygulamalar olabilir.

    Attribute sınıfları da Exception sınıflarına benzer şekilde aynı son ekle biterler.
    Attribute sınıfından türerler.
*/
namespace Validators;

/*
    Aşağıdaki nitelik sadece sınıflara uygulanır. Hiç bir üyesi olmasa da çalışma zamanına ekstra bilgi içerir.
    Örneğin veri doğrulaması yapan bir servis sadece bu nitelik ile giydirilmiş sınıfları ele alır.
*/

[AttributeUsage(AttributeTargets.Class)]
public class ValidatorAttribute
    : Attribute
{
}

/*
    Bu nitelik ise pozitif tamsayı aralığı için bir doğrulama kriteri tanımlar.
    Sadece özellikler uygulanır. Örneğin stok seviyesini taşıyan bir özelliğe uygulanabilir ve 
    çalışma zamanı ilgili özellikte bu nitelik varsa MaxValue ve MinValue değerlerine bakarak
    nasıl bir aralık için değer kontrol yapması gerektiğini bilebilir.
*/

[AttributeUsage(AttributeTargets.Property)] // RangeValidatorAttribute' un sadece Property'lere uygulanacağını belirtir
public class NumberRangeValidatorAttribute // Bu konudaki sınıf adları Attribute kelimesi ile biter
    : Attribute
{
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public NumberRangeValidatorAttribute()
        : this(1, 100)
    { }
    public NumberRangeValidatorAttribute(int min, int max)
    {
        if (min > max)
        {
            // Exception'da verilebilir hatta Custom Exception tipi de ele alınabilir
            var temp = min;
            MaxValue = temp;
            MinValue = max;
        }
    }
}
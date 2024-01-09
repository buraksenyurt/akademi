using System.Reflection;
using Validators;

namespace ServiceRuntime;

public class ValidatorRuntime
{
    public static bool Apply<T>(T instance)
        where T : notnull // Gelen generic T türünün null olmaması kısıtını ekler
    {
        var instanceType = instance.GetType(); // Tip bilgisi alınır
        // Bu tipe ValidatorAttribute uygulanmış mı bakılır
        if (instanceType.GetCustomAttribute(typeof(ValidatorAttribute)) != null)
        {
            // Özellikler çekilir
            var properties = instanceType.GetProperties();
            // Her bir özelliğe bakılır
            foreach (var property in properties)
            {
                // Eğer söz konusu özelliğe uygulanmış NumberRangeValidatorAttribute varsa
                var nmrRngAttr = property.GetCustomAttribute(attributeType: typeof(NumberRangeValidatorAttribute));
                if (nmrRngAttr != null)
                {                    
                    var attr = (NumberRangeValidatorAttribute)nmrRngAttr;
                    // Property'nin taşıdığı değer alınır
                    var propValue = (int)property.GetValue(instance);
                    // attribute ile belirlenen kıstaslara bakılır ve valid olup olmamasına göre cevap dönülür
                    //Console.WriteLine($"{property.Name} = {propValue} Attribute Min Value ={attr.MinValue} Max Value = {attr.MaxValue}");
                    if (propValue < attr.MinValue || propValue > attr.MaxValue)
                        return false;
                }
            }
        }
        return true;
    }
}
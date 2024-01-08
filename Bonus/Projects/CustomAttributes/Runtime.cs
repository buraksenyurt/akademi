using System.Reflection;
using Validators;

namespace ServiceRuntime;

public class ValidatorRuntime
{
    public bool Apply<T>(T instance)
    {
        var instanceType = instance.GetType();
        if (instanceType.GetCustomAttribute(typeof(ValidatorAttribute)) != null)
        {
            Console.WriteLine("Validator uygulanmış");
            var properties = instanceType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttribute(typeof(NumberRangeValidatorAttribute)) != null)
                {
                    Console.WriteLine(property.Name);
                    //TODO@buraksenyurt İlgili niteliğe göre doğrulama işlemleri eklenecek
                }
            }
        }
        return false;
    }
}
using Northwind;
using ServiceRuntime;

var runT = new ValidatorRuntime();
var stockInfo = new Stock
{
    ProductId = 1,
    Product = "VGA Graphics Adaptor",
    Quantity = 15
};

for (int i = 1; i < 10; i++)
{
    var isValid = ValidatorRuntime.Apply(stockInfo) ? "Valid" : "Invalid";
    Console.WriteLine($"Current Stock Value : {stockInfo.Quantity} and {isValid}");
    stockInfo.Quantity += 10;
}

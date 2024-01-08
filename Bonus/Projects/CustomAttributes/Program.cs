using Northwind;
using ServiceRuntime;

var runT = new ValidatorRuntime();
var stockInfo = new Stock
{
    ProductId = 1,
    Product = "VGA Graphics Adaptor",
    Quantity = 25
};

var isValid = runT.Apply(stockInfo);
Console.WriteLine(isValid);

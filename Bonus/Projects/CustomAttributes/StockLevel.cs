using Validators;

namespace Northwind;

[Validator]
public class Stock
{
    public int ProductId { get; set; }
    public required string Product { get; set; }
    [NumberRangeValidator(MinValue = 10, MaxValue = 50)]
    public int Quantity { get; set; }    
}
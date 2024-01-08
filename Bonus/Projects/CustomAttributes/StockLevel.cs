using Validators;

namespace Northwind;

[Validator]
public class Stock
{
    public int ProductId { get; set; }
    public required string Product { get; set; }
    [NumberRangeValidator(10, 50)]
    public int Quantity { get; set; }
}
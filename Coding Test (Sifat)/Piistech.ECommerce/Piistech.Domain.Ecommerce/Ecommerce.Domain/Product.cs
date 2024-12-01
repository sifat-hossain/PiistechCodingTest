namespace Piistech.Domain.Ecommerce.Ecommerce.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsDeleted { get; set; }
}

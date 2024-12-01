using System.Text.Json.Serialization;

namespace PiistechEcommerce.Web.Models;

public class Product
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }
}

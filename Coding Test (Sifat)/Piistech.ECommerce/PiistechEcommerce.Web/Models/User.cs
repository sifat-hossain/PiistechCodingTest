using System.Text.Json.Serialization;

namespace PiistechEcommerce.Web.Models;

public class User
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }
    public string Password { get; set; }

}

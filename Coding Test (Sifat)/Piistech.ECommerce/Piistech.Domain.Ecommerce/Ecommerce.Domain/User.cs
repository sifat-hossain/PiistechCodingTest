﻿namespace Piistech.Domain.Ecommerce.Ecommerce.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool IsDeleted { get; set; }
}

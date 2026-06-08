using api.Attributes;

namespace api.Models;

[RequireOne(nameof(Email), nameof(Phone))]
public class Person
{
    public Guid Id { get; set; }
    public Guid AddressGuid { get; set; }
    public string FirstName { get; set; } = "";
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = "";
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? ImageSrc { get; set; }
}

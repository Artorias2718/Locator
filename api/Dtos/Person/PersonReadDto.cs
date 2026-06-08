namespace api.Dtos.Person;

public class PersonReadDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string ImageSrc { get; set; } = "";
}
using api.Dtos.Person;

namespace api.Domain.Person;

public interface IPersonDomainGet
{
    public Task<PersonReadDto?> GetPerson(string identifier);
}
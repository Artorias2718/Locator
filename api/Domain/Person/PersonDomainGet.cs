using System.Collections;
using api.DbContexts;
using api.Dtos;
using api.Dtos.Person;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Domain.Person;

public class PersonDomainGet(SqlServerContext sqlServerContext, IMapper mapper) : IPersonDomainGet
{
    public async Task<PersonReadDto?> GetPerson(string identifier)
    {
        var person = await sqlServerContext.Person
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower().Contains(identifier.ToLower()) || x.Phone.Contains(identifier));

        if (person is null)
        {
            return null;
        }

        return mapper.Map<PersonReadDto>(person);
    }
}
using api.Dtos;
using api.Dtos.Person;
using api.Models;
using AutoMapper;

namespace api.Profiles;

public class PersonProfile: Profile
{
    public PersonProfile()
    {
        CreateMap<Models.Person, PersonReadDto>();
    }
}

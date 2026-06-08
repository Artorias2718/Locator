using api.Domain.Person;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(IPersonDomainGet domainGet) : ControllerBase
{
    [HttpGet("[action]/{identifier}")]
    public async Task<IActionResult> GetPerson(string identifier)
    {
        var result = await domainGet.GetPerson(identifier);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}

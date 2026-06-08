using api.Models;

namespace api.DbContexts;

public class DataSeeder(SqlServerContext sqlServerContext)
{
    public async Task SeedDataAsync(SqlServerContext context)
    {
        if (!sqlServerContext.Person.Any())
        {
            await SeedPerson(context);
        }
    }

    private async Task SeedPerson(SqlServerContext sqlServerContext)
    {
        Person[] persons =
        [
            new Person
            {
                FirstName = "Dario",
                LastName = "Ordonez",
                Email = "darior1961@gmail.com",
                Phone = "18016860627"
            },
            new Person
            {
                FirstName = "Irma",
                LastName = "Ordonez",
                Email = "irmaord87@gmail.com",
                Phone = "18016688475"
            },
            new Person
            {
                FirstName = "Diana",
                LastName = "Fox-Lynch",
                Email = "diana.fox0417@gmail.com",
                Phone = "18014521407"
            },
            new Person
            {
                FirstName = "Arturo",
                LastName = "Ordonez-Hernandez",
                Email = "arturoordonez2718@gmail.com",
                Phone = "18016689018"
            },
            new Person
            {
                FirstName = "Ulises",
                LastName = "Ordonez-Hernandez",
                Email = "ulisesord6@gmail.com",
                Phone = "18018568628"
            }
        ];

        sqlServerContext.Person.AddRange(persons);
        await sqlServerContext.SaveChangesAsync();
    }

}
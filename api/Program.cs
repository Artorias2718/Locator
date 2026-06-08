using api.DbContexts;
using api.Domain.Person;
using api.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<PersonProfile>();
});

var corsPolicy = "_corsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder =>
    {
        builder.WithOrigins(["http://localhost:5173"])
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IPersonDomainGet, PersonDomainGet>();

builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddTransient<DataSeeder>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
       using (var scope = app.Services.CreateScope())
       {
           var services = scope.ServiceProvider;

           try
           {
               var sqlServerContext = services.GetRequiredService<SqlServerContext>();
               var seeder = services.GetRequiredService<DataSeeder>();
               await seeder.SeedDataAsync(sqlServerContext);
           }
           catch (Exception ex)
           {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex, "An error occured while seeding the database");
           }
       }
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

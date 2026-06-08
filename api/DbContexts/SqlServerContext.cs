using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api.DbContexts;

public class SqlServerContext: DbContext
{
    public DbSet<Person> Person { get; set; }

    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
    }
}
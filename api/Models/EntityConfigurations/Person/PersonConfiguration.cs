using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityConfigurations.Person;

public class PersonConfiguration: IEntityTypeConfiguration<Models.Person>
{
    public void Configure(EntityTypeBuilder<Models.Person> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);
        builder.Property(e => e.MiddleName)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);
        builder.Property(e => e.LastName)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);
        builder.Property(e => e.Email)
            .HasColumnType("nvarchar(255)")
            .IsRequired(true);
        builder.Property(e => e.Phone)
            .HasColumnType("varchar(11)")
            .IsRequired(true);
        builder.Property(e => e.ImageSrc)
            .HasColumnType("varchar(max)")
            .IsRequired(false);
    }
}

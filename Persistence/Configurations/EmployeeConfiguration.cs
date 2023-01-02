using Microsoft.EntityFrameworkCore;
using minimal_api.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace minimal_api.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Gender)
            .HasMaxLength(1)
            .IsRequired();
    }
}
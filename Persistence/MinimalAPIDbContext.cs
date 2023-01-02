using Microsoft.EntityFrameworkCore;
using minimal_api.Persistence.Models;

namespace minimal_api.Persistence;

public class MinimalApiDbContext : DbContext
{
    public MinimalApiDbContext(DbContextOptions<MinimalApiDbContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinimalApiDbContext).Assembly);
    }

    public  DbSet<Employee> Employees { get; set; }
}
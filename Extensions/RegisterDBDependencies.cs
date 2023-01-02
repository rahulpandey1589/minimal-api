using Microsoft.EntityFrameworkCore;
using minimal_api.Persistence;

namespace minimal_api.Extensions;

public static class RegisterDBDependencies
{
    public static IServiceCollection RegisterPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MinimalApiDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}
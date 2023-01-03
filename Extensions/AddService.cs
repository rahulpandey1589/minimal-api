using System.Reflection;
using minimal_api.Jobs;
using minimal_api.Models;
using minimal_api.Contracts;
using minimal_api.Implementation;

namespace minimal_api.Extensions;

public static class AddService
{
    public static WebApplicationBuilder AddDepedencies(
        this WebApplicationBuilder builder)
    {
        RegisterServices(builder);

        builder.Services.Configure<PageModel>(
            builder.Configuration.GetSection("PageModel"));

        builder.Services.AddHttpClient("ResAPI", client =>
        {
            client.BaseAddress = new Uri(
                builder.Configuration.GetSection("Configuration:BaseUrl").Value);
        });
        return builder;
    }

    public static WebApplicationBuilder RegisterServices(
        WebApplicationBuilder builder)
    {
       // builder.Services.AddHostedService<BackgroundJobs>();
       builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddTransient<IUserService, UserService>();

        return builder;
    }
}
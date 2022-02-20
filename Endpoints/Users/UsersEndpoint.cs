namespace minimal_api.Endpoints.Users;

public static class UsersEndpoint
{
    public static IEndpointRouteBuilder AddUserEndpoint(
        this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/users", GetUsers());
        
        return routes;
    }
}
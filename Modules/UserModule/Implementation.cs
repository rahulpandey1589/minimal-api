using AutoMapper;
using Carter;
using minimal_api.Contracts;
using minimal_api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace minimal_api.Modules.UserModule;

public class Implementation : ICarterModule
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public Implementation(
        IMemoryCache memoryCache,
        IUserService userService,
        IMapper mapper)
    {
        _memoryCache = memoryCache;
        _userService = userService;
        this._mapper = mapper;
    }

    public void AddRoutes(
        IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", GetUsers).WithName("Users");
    }
    
    private async Task<IEnumerable<Users>> GetUsers()
    {
        if (_memoryCache.TryGetValue("Users", out IEnumerable<Users> users))  return await Task.FromResult(users);
        else
        {
            users = await _userService.FetchUsers();
            _memoryCache.Set("Users", users);
            return await Task.FromResult(users);
        }

    }
}
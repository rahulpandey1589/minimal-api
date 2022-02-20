using Microsoft.Extensions.Caching.Memory;
using minimal_api.Contracts;

namespace minimal_api.Jobs;

public class BackgroundJobs : BackgroundService
{
    private readonly ILogger<BackgroundJobs> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly IUserService _userService;

    public BackgroundJobs(
        ILogger<BackgroundJobs> logger, 
        IMemoryCache memoryCache,
        IUserService userService)
    {
        _logger = logger;
        _memoryCache = memoryCache;
        _userService = userService;
    }
    
    
    protected override async Task<Task> ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _logger.LogInformation("Started background jobs at : {Data}", DateTime.Now);

        if (!stoppingToken.IsCancellationRequested)
        {
            _memoryCache.Set("Users",
                await _userService.FetchUsers(),
                new MemoryCacheEntryOptions());

            _logger.LogInformation("Data from remote API is fetched at {Datetime}",DateTime.Now);
        }
        return Task.CompletedTask;
    }

    public override Task StopAsync(
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("The background job stopped at {DateTime}",DateTime.Now);
        return base.StopAsync(cancellationToken);
    }
}
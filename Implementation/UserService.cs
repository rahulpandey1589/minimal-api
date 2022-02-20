using System.Text.Json;
using Microsoft.Extensions.Options;
using minimal_api.Contracts;
using minimal_api.Models;

namespace minimal_api.Implementation;

public class UserService : IUserService
{
    private readonly IOptionsMonitor<PageModel> _pageModel;
    private readonly HttpClient _client;

    public UserService(
        IOptionsMonitor<PageModel> pageModel, 
        IHttpClientFactory clientFactory)
    {
        _pageModel = pageModel;
        _client = clientFactory.CreateClient("ResAPI");
    }

    public async Task<IEnumerable<Users>> FetchUsers()
    {
        var pageNumber = _pageModel.CurrentValue.PageNumber;
        var httpResponse = await _client.GetAsync("users?page=" + pageNumber);

        if (!httpResponse.IsSuccessStatusCode) return new List<Users>();

        await using var contentStream =
            await httpResponse.Content.ReadAsStreamAsync();
        var response = await JsonSerializer.DeserializeAsync<Root>(contentStream);

        return response?.data;
    }
}
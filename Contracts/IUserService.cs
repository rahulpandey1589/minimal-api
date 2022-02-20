using minimal_api.Models;

namespace minimal_api.Contracts;

public interface IUserService
{
    Task<IEnumerable<Users>> FetchUsers();
}
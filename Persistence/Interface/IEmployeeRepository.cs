using minimal_api.Models;
using minimal_api.Persistence.Models;

namespace minimal_api.Persistence.Interface;

public interface IEmployeeRepository
{
    int InsertEmployee(Employee employee);
}
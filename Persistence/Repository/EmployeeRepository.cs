using minimal_api.Models;
using minimal_api.Persistence.Models;
using minimal_api.Persistence.Interface;

namespace minimal_api.Persistence.Repository;

public class EmployeeRepository : GenericRepository<EmployeeModel>, IEmployeeRepository
{
    private readonly MinimalApiDbContext _dbContext;
    
    public EmployeeRepository(
        MinimalApiDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public int InsertEmployee(Employee employee)
    {
        var response = _dbContext.Employees.Add(employee);

        return response.Entity.Id;
    }
}
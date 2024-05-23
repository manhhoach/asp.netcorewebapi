using Entities.Models;

namespace Contracts.IRepository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

    }
}

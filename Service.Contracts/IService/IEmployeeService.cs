using Shared.DataTransferObjects;

namespace Service.Contracts.IService
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    }
}

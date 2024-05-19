using Service.Contracts.IService;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }
        IEmployeeService EmployeeService { get; }
    }
}

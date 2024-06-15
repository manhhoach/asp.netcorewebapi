using Service.Contracts.IService;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICompanyService Company { get; }
        IEmployeeService Employee { get; }
        IAuthenticationService Authentication { get; }
    }
}

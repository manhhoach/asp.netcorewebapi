using Shared.DataTransferObjects;

namespace Service.Contracts.IService
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);

    }
}

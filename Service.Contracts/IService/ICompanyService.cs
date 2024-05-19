using Entities.Models;

namespace Service.Contracts.IService
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

    }
}

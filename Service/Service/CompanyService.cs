using Contracts;
using Entities.Models;
using LoggerService;
using Service.Contracts.IService;

namespace Service.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies =_repositoryManager.Company.GetAllCompanies(trackChanges);
                return companies;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)}: {ex.Message}");
                throw;
            }
        }
    }
}

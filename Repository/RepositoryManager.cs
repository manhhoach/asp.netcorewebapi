using Contracts;
using Contracts.IRepository;
using Repository.Repository;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(_repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_repositoryContext));
        }
        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee { get { return _employeeRepository.Value; } }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

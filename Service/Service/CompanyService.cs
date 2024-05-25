using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using LoggerService;
using Service.Contracts.IService;
using Shared.DataTransferObjects;

namespace Service.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var data = _mapper.Map<Company>(company);
            _repositoryManager.Company.CreateCompany(data);
            _repositoryManager.Save();
            var companyDto = _mapper.Map<CompanyDto>(data);
            return companyDto;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {

            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;

        }
        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(id, trackChanges);
            if (company is null)
            {
                throw new CompanyNotFoundException(id);
            }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }
}

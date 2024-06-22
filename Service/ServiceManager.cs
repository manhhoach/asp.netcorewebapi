using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Service.Contracts.IService;
using Service.Service;
using Shared.DataTransferObjects;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            IDataShaper<EmployeeDto> dataShaper,
            UserManager<User> userManager,
            IOptions<JwtConfiguration> configuration,
            IConfiguration config
            )
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, dataShaper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, config));
        }

        public ICompanyService Company => _companyService.Value;

        public IEmployeeService Employee => _employeeService.Value;

        public IAuthenticationService Authentication => _authenticationService.Value;
    }
}

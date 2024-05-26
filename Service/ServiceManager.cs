﻿using AutoMapper;
using Contracts;
using LoggerService;
using Service.Contracts;
using Service.Contracts.IService;
using Service.Service;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
        }

        public ICompanyService Company => _companyService.Value;

        public IEmployeeService Employee => _employeeService.Value;
    }
}

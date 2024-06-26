﻿using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts.IRepository
{
    public interface IEmployeeRepository
    {
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);

        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

    }
}

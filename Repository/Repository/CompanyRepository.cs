﻿using Contracts.IRepository;
using Entities.Models;

namespace Repository.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Company GetCompany(Guid companyId, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
        }
    }
}

using Entities.Extensions;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    // [ApiVersion("1.0")]
    [Route("api/companies")]
    [ApiController]
    // [ResponseCache(CacheProfileName = "120SecondsDuration")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CompaniesController : ApiControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CompaniesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary> 
        /// Gets the list of all companies 
        /// </summary> 
        /// <returns>The companies list</returns> 
        // [ResponseCache(Duration = 60)]
        [Authorize]
        [HttpGet(Name = "GetCompanies")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _serviceManager.Company.GetAllCompaniesAsync(false);
            return Ok(companies);

        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _serviceManager.Company.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            var createdCompany = await _serviceManager.Company.CreateCompanyAsync(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companyEntities = await _serviceManager.Company.GetByIdsAsync(ids, false);
            return Ok(companyEntities);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _serviceManager.Company.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids },
            result.companies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _serviceManager.Company.DeleteCompanyAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            await _serviceManager.Company.UpdateCompanyAsync(id, company, trackChanges: true);
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }


        [HttpGet]
        [Route("GetCompaniesNotAsync")]
        public IActionResult GetCompaniesNotAsync()
        {
            var baseResult = _serviceManager.Company.GetAllCompanies(trackChanges: false);

            var companies = baseResult.GetResult<IEnumerable<CompanyDto>>();

            return Ok(companies);
        }

        [HttpGet]
        [Route("GetCompanyNotAsync/{id:Guid}")]
        public IActionResult GetCompanyNotAsync(Guid id)
        {
            var baseResult = _serviceManager.Company.GetCompany(id, trackChanges: false);
            if (!baseResult.Success)
                return ProcessError(baseResult);

            var company = baseResult.GetResult<CompanyDto>();
            return Ok(company);
        }
    }
}

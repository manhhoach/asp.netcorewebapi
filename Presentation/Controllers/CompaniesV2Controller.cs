using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    //  [ApiVersion("2.0", Deprecated = true)]
    [Route("api/companies")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesV2Controller(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.Company.GetAllCompaniesAsync(trackChanges: false);
            var companiesV2 = companies.Select(x => $"{x.Name} V2").ToList();
            return Ok(companiesV2);
        }
    }
}

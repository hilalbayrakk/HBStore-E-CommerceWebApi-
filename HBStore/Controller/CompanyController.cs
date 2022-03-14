using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("add")]
        public async Task<Company> Add(Company company)
        {
            await _companyService.AddCompanyAsync(company);
            return company;
        }

        [HttpPut("update")]
        public async Task<Company> Update([FromQuery] int id, Company company)
        {
            return await _companyService.UpdateCompanyAsync(id, company);
        }

        [HttpDelete]
        public async Task Delete(Company company)
        {
            await _companyService.DeleteCompanyAsync(company);
        }

        [HttpGet("getall")]
        public async Task<List<Company>> GetCompanyAsync(Company company)
        {
            return await _companyService.GetAllCompanyAsync();
        }

        [HttpGet("getbyid")]
        public async Task<Company> GetByCompanyIdAsync([FromQuery] int companyId)
        {
            return await _companyService.GetByCompanyIdAsync(companyId);
        }

        [HttpGet("getbyname")]
        public async Task<Company> GetByCompanyName([FromQuery] string companyName)
        {
            return await _companyService.GetByCompanyNameAsync(companyName);
        }
    }
}
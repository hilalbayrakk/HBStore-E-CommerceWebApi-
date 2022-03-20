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
            await _companyService.AddCompany(company);
            return company;
        }

        [HttpPut("update")]
        public async Task<Company> Update([FromQuery] int id, Company company)
        {
            return await _companyService.UpdateCompany(id, company);
        }

        [HttpDelete]
        public async Task Delete(Company company)
        {
            await _companyService.DeleteCompany(company);
        }

        [HttpGet("getall")]
        public async Task<List<Company>> GetCompany(Company company)
        {
            return await _companyService.GetAllCompany();
        }

        [HttpGet("getbyid")]
        public async Task<Company> GetByCompanyId([FromQuery] int companyId)
        {
            return await _companyService.GetByCompanyId(companyId);
        }

        [HttpGet("getbyname")]
        public async Task<Company> GetByCompanyName([FromQuery] string companyName)
        {
            return await _companyService.GetByCompanyName(companyName);
        }
    }
}
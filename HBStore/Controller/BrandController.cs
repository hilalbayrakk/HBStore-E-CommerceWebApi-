namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<Brand> Add(Brand brand)
        {
            return await _brandService.AddBrand(brand);

        }
        [HttpPut("update")]
        public async Task<Brand> Update([FromQuery] Brand brand, int id)
        {
            return await _brandService.UpdateBrand(brand, id);
        }
        [HttpDelete]
        public async Task Delete(Brand brand)
        {
            await _brandService.DeleteBrand(brand);
        }
        [HttpGet("getall")]
        public async Task<List<Brand>> GetAll()
        {
            return await _brandService.GetAllBrand();
        }
        [HttpGet("getbyid")]
        public async Task<Brand> GetBrandByIdAsync([FromQuery] int brandId)
        {
            return await _brandService.GetByBrandId(brandId);
        }
        [HttpGet]
        public async Task<Brand> GetBrandByName([FromQuery] string brandName)
        {
            return await _brandService.GetByBrandName(brandName);
        }
    }
}
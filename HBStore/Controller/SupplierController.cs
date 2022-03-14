using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface.InterfaceService;
using HBStore.DTO;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierDTO>> GetAllSupplier()
        {
            return await _supplierService.GetAllSupplier();
        }

        [HttpGet("{id}")]
        public async Task<SupplierDTO> GetSupplierById(int id)
        {
            return await _supplierService.GetSupplierById(id);
        }

        [HttpGet("name")]
        public async Task<SupplierDTO> GetSupplierByName(string name)
        {
            return await _supplierService.GetSupplierByName(name);
        }

        [HttpGet("email")]
        public async Task<SupplierDTO> GetSupplierByEmail(string email)
        {
            return await _supplierService.GetSupplierByEmail(email);
        }

        [HttpGet("rating")]
        public async Task<IEnumerable<SupplierDTO>> GetSupplierByRating(string Rating)
        {
            return await _supplierService.GetSupplierByRating(Rating);
        }

        [HttpGet("minrating")]
        public async Task<IEnumerable<SupplierDTO>> GetSupplierByMinRatingAndAbove(string MinRating)
        {
            return await _supplierService.GetSupplierByMinRatingAndAbove(MinRating);
        }

        [HttpGet("ratingrange")]
        public async Task<IEnumerable<SupplierDTO>> GetSupplierByRatingRange(string DownRating, string UpRating)
        {
            return await _supplierService.GetSupplierByRatingRange(DownRating, UpRating);
        }

        [HttpPost]
        public async Task<SupplierDTO> CreateSupplierOperation(SupplierDTO supplier)
        {
            return await _supplierService.CreateSupplierOperation(supplier);
        }

        [HttpPut("{id}")]
        public async Task<SupplierDTO> UpdateSupplierOperation(int id, SupplierDTO supplier)
        {
            return await _supplierService.UpdateSupplierOperation(id, supplier);
        }

        [HttpDelete("{id}")]
        public async Task<SupplierDTO> DeleteSupplierOperation(int id)
        {
            return await _supplierService.DeleteSupplierOperation(id);
        }
    }
}
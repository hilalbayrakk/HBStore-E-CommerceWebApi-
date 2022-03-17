using HBStore.DTO;
using HBStore.Model;

namespace HBStore.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAllSupplier();
        Task<SupplierDTO> GetSupplierById(int id);
        Task<SupplierDTO> GetSupplierByName(string name);
        Task<IEnumerable<SupplierDTO>> GetSupplierByRating(string Rating);
        Task<IEnumerable<SupplierDTO>> GetSupplierByMinRatingAndAbove(string MinRating);
        Task<IEnumerable<SupplierDTO>> GetSupplierByRatingRange(string DownRating, string UpRating);
        IEnumerable<SupplierDTO> SupplierToSupplierDTO(IEnumerable<Supplier> suppliers);

        Task<SupplierDTO> CreateSupplierOperation(SupplierDTO supplier);
        Task<SupplierDTO> UpdateSupplierOperation(int id, SupplierDTO supplier);
        Task<SupplierDTO> DeleteSupplierOperation(int id);

    }
}
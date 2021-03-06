namespace HBStore.Interface
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(int id);
        Task<Supplier> GetSupplierByName(string name);
        Task<IEnumerable<Supplier>> GetSupplierByRating(double Rating);
        Task<IEnumerable<Supplier>> GetSupplierByMinRatingAndAbove(double MinRating);
        Task<IEnumerable<Supplier>> GetSupplierByRatingRange(double DownRating, double UpRating);
        Task<Supplier> CreateSupplierOperation(SupplierDTO supplier);
        Task<Supplier> UpdateSupplierOperation(int id, SupplierDTO supplier);
        Task<Supplier> ChangeSupplierVisibility(int id);


    }
}
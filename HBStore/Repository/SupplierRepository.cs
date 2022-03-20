namespace HBStore.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public readonly HBStoreDbContext _context;

        public SupplierRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> ChangeSupplierVisibility(int id)
        {
            try
            {
                Supplier sp = await _context.Suppliers.FindAsync(id);
                sp.IsVisibility = !sp.IsVisibility;

                await _context.SaveChangesAsync();

                return sp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Supplier> CreateSupplierOperation(SupplierDTO supplier)
        {
            try
            {
                Supplier persistSupplier = new Supplier(supplier);

                _context.Set<Supplier>().Add(persistSupplier);
                await _context.SaveChangesAsync();
                return persistSupplier;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetSupplierByMinRatingAndAbove(double MinRating)
        {
            try
            {
                var SupplierListAsync = await (from item in _context.Suppliers
                                               where item.Rating >= MinRating
                                               select item).ToListAsync();
                if (SupplierListAsync != null)
                {
                    return SupplierListAsync;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Supplier> GetSupplierByName(string name)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Supplier>> GetSupplierByRating(double Rating)
        {

            try
            {
                var SupplierListAsync = await (from item in _context.Suppliers
                                               where item.Rating == Rating
                                               select item).ToListAsync();
                if (SupplierListAsync != null)
                {
                    return SupplierListAsync;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<IEnumerable<Supplier>> GetSupplierByRatingRange(double DownRating, double UpRating)
        {
            try
            {
                var SupplierListAsync = await (from item in _context.Suppliers
                                               where (item.Rating >= DownRating && item.Rating <= UpRating)
                                               select item).ToListAsync();
                if (SupplierListAsync != null)
                {
                    return SupplierListAsync;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Supplier> UpdateSupplierOperation(int id, SupplierDTO supplier)
        {
            try
            {
                var sp = await _context.Suppliers.FindAsync(id);
                sp.Name = supplier.Name;
                sp.Account = supplier.Account;
                sp.Address = supplier.Address;
                sp.Brand = supplier.Brand;
                sp.Rating = supplier.Rating;
                sp.IsVisibility = supplier.IsVisibility;

                await _context.SaveChangesAsync();
                return sp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


using HBStore.Context;
using HBStore.DTO;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public readonly HBStoreDbContext _context;

        public SupplierRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            try
            {
                List<Supplier> temp = await (from db in _context.Suppliers select db).ToListAsync();
                return temp;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<Supplier> ChangeSupplierVisibility(int id)
        {
            throw new NotImplementedException();
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
            catch (Exception e)
            {
                return null;
            }

        }


        public async Task<Supplier> GetSupplierByEmail(string email)
        {
            try
            {
                Supplier? supplier = await (from sp in _context.Suppliers
                                            where sp.Account.Email == email
                                            select sp).FirstOrDefaultAsync();
                if (supplier != null)
                {
                    return supplier;
                }
                return null;


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            try
            {
                Supplier? supplier = await _context.Suppliers!.FindAsync(id);
                if (supplier != null)
                {
                    return supplier;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

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


        public async Task<Supplier> GetSupplierByName(string Name)
        {
            string name = "";
            string[] temp = Name.Split('-');
            for (int i = 0; i < temp.Length; i++)
            {
                name += temp[i];
                if (i < temp.Length - 1)
                    name += " ";
            }
            try
            {
                Supplier? supplier = await (from sp in _context.Suppliers
                                            where sp.Name == name
                                            select sp).FirstOrDefaultAsync();
                if (supplier != null)
                {
                    return supplier;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

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
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
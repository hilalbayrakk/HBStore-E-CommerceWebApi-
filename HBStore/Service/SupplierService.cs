namespace HBStore.Service
{
    public class SupplierService : ControllerBase, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        

        public async Task<IEnumerable<SupplierDTO>> GetSupplierByMinRatingAndAbove(string MinRating)
        {
            double minrating = 0;
            var min = double.TryParse(MinRating, out minrating);
            if (!min)
            {
                throw new NotImplementedException();
            }
            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByMinRatingAndAbove(minrating));
        }

        public async Task<IEnumerable<SupplierDTO>> GetSupplierByRating(string Rating)
        {
            double _rating = 0;
            var min = double.TryParse(Rating, out _rating);
            if (!min)
            {
                throw new NotImplementedException();
            }
            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByRating(_rating));
        }

        public async Task<IEnumerable<SupplierDTO>> GetSupplierByRatingRange(string DownRating, string UpRating)
        {
            double down_rating = 0, up_rating = 0;
            var down = double.TryParse(DownRating, out down_rating);
            var up = double.TryParse(UpRating, out up_rating);
            if (!down || !up)
            {
                throw new NotImplementedException();
            }

            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByRatingRange(down_rating, up_rating));
        }

        public IEnumerable<SupplierDTO> SupplierToSupplierDTO(IEnumerable<Supplier> suppliers)
        {
            List<SupplierDTO> supplierDTOs = new List<SupplierDTO>();
            foreach (Supplier item in suppliers)
            {
                SupplierDTO temp = new SupplierDTO();
                temp.Name = item.Name;
                temp.Account = item.Account;
                temp.Address = item.Address;
                temp.Brand = item.Brand;
                temp.Rating = item.Rating;
                temp.IsVisibility = item.IsVisibility;
                supplierDTOs.Add(temp);
            }
            return supplierDTOs;
        }

       public async Task<SupplierDTO> CreateSupplierOperation(SupplierDTO supplier)
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierByName(supplier.Name));
            if (supplierDTO == null)
            {
                return new SupplierDTO(await _supplierRepository.CreateSupplierOperation(supplier));
            }
            throw new InvalidOperationException("Ayni isimde baska bir tedarikci bulunuyor!");
        }

        public async Task<SupplierDTO> DeleteSupplierOperation(int id)
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return new SupplierDTO(await _supplierRepository.ChangeSupplierVisibility(id));
            }
            throw new InvalidOperationException("Silinecek tedarikci bulunamadi!");
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllSupplier()
        {
            IEnumerable<SupplierDTO> supplierDTOs = SupplierToSupplierDTO(await _supplierRepository.GetAllSupplier());
            if (supplierDTOs != null)
            {
                return supplierDTOs;
            }
            return new List<SupplierDTO> { new SupplierDTO(null) };
        }

        public async Task<SupplierDTO> GetSupplierById(int id)
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return supplierDTO;
            }
            throw new InvalidOperationException("Bu ID'ye sahip bir tedarikci bulunamadi!");
        }

        public async Task<SupplierDTO> GetSupplierByName(string name)
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierByName(name));
            if (supplierDTO != null)
            {
                return supplierDTO;
            }
            throw new InvalidOperationException("Bu isme sahip bir tedarikci bulunamadi!");
        }

        public async Task<SupplierDTO> UpdateSupplierOperation(int id, SupplierDTO supplier)
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return new SupplierDTO(await _supplierRepository.UpdateSupplierOperation(id, supplier));
            }
            throw new InvalidOperationException("Guncellenecek tedarikci bulunamadi!");
        }
    }

}
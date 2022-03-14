using HBStore.Interface;
using HBStore.Model;

namespace HBStore.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            var result = await _companyRepository.GetByCompanyNameAsync(company.Name);
            if(result == null)
            {
                await _companyRepository.AddCompanyAsync(company);
                return company;
            }
            throw new Exception("Aynı isimde baska bir sirket bulunmaktadir!");
        }

        public async Task DeleteCompanyAsync(Company company)
        {
           var result = await _companyRepository.GetByCompanyIdAsync(company.Id);
           if(result != null)
           {
               await _companyRepository.DeleteCompanyAsync(company);
           }
           throw new Exception("Silinecek sirket bulunamadi!");
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            var result = await _companyRepository.GetByCompanyIdAsync(id);
            if(result != null)
            {
                result = company;
                await _companyRepository.UpdateCompanyAsync(result);
                return company;
            }
             throw new Exception("Guncellenecek sirket bulunamadi!");
        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await _companyRepository.GetAllCompanyAsync();
        }

        public async Task<Company> GetByCompanyIdAsync(int companyId)
        {
           return await _companyRepository.GetByCompanyIdAsync(companyId);
        }

        public async Task<Company> GetByCompanyNameAsync(string companyName)
        {
            return await _companyRepository.GetByCompanyNameAsync(companyName);
        }


    }
}
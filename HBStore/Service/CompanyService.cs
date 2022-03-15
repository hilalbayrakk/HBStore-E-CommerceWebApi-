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

        public async Task<Company> AddCompany(Company company)
        {
            var result = await _companyRepository.GetByCompanyName(company.Name);
            if(result == null)
            {
                await _companyRepository.AddCompany(company);
                return company;
            }
            throw new Exception("Aynı isimde baska bir sirket bulunmaktadir!");
        }

        public async Task DeleteCompany(Company company)
        {
           var result = await _companyRepository.GetByCompanyId(company.Id);
           if(result != null)
           {
               await _companyRepository.DeleteCompany(company);
           }
           throw new Exception("Silinecek sirket bulunamadi!");
        }

        public async Task<Company> UpdateCompany(int id, Company company)
        {
            var result = await _companyRepository.GetByCompanyId(id);
            if(result != null)
            {
                result = company;
                await _companyRepository.UpdateCompany(result);
                return company;
            }
             throw new Exception("Guncellenecek sirket bulunamadi!");
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _companyRepository.GetAllCompany();
        }

        public async Task<Company> GetByCompanyId(int companyId)
        {
           return await _companyRepository.GetByCompanyId(companyId);
        }

        public async Task<Company> GetByCompanyName(string companyName)
        {
            return await _companyRepository.GetByCompanyName(companyName);
        }


    }
}
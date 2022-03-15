using HBStore.Model;

namespace HBStore.Interface
{
    public interface ICompanyService
    {
        Task<Company> AddCompany(Company company);
        Task DeleteCompany(Company company);
        Task<Company> UpdateCompany(int id, Company company);
        Task<List<Company>> GetAllCompany();
        Task<Company> GetByCompanyId(int companyId);
        Task<Company> GetByCompanyName(string companyName);
    }
}
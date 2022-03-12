using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface ICompanyService
    {
        Task<Company> AddCompanyAsync(Company company);
        Task DeleteCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(int id, Company company);
        Task<List<Company>> GetAllCompanyAsync();
        Task<Company> GetByCompanyIdAsync(int companyId);
        Task<Company> GetByCompanyNameAsync(string companyName);
    }
}
using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface ICompanyRepository
    {
        Task<Company> AddCompanyAsync(Company company);
         Task DeleteCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<List<Company>> GetAllCompanyAsync();
        Task<Company> GetByCompanyIdAsync(int companyId);
        Task<Company> GetByCompanyNameAsync(string companyName);

    }
}
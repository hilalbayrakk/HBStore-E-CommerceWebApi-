namespace HBStore.Interface
{
    public interface ICompanyRepository
    {
        Task<Company> AddCompany(Company company);
         Task DeleteCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<List<Company>> GetAllCompany();
        Task<Company> GetByCompanyId(int companyId);
        Task<Company> GetByCompanyName(string companyName);

    }
}
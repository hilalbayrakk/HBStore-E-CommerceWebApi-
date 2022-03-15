using HBStore.Context;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;
namespace HBStore.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly HBStoreDbContext _context;

        public CompanyRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Company> AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetByCompanyId(int companyId)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<Company> GetByCompanyName(string companyName)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Name == companyName);
        }


    }
}
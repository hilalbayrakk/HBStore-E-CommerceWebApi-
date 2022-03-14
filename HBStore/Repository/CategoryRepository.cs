using HBStore.Context;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HBStoreDbContext _context;

        public CategoryRepository(HBStoreDbContext context)
        {
            _context = context;
        }

       public async Task<Category>AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByCategoryId(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<Category> GetByCategoryName(string categoryName)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        }

        public async Task<List<Category>> GetSubCategoriesByCategoryName(string categoryName)
        {
            return await (from category in _context.Categories
                        where category.Name == categoryName
                        select category.SubCategories).FirstOrDefaultAsync();
        }

    }
}
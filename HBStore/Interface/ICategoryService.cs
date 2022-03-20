namespace HBStore.Interface
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category);
        Task DeleteCategory(Category category);
        Task<Category> UpdateCategory(int id, Category category);
        Task<List<Category>> GetAllCategory();
        Task<Category> GetByCategoryId(int categoryId);
        Task<Category> GetByCategoryName(string categoryName);
        Task<List<Category>> GetSubCategoriesByCategoryName(string categoryName);
    }
}
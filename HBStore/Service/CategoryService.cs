namespace HBStore.Service
{
    public class CategoryService : ControllerBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await _categoryRepository.GetByCategoryName(category.Name);
            if(result == null)
            {
                return await _categoryRepository.AddCategory(category);
            }
            throw new InvalidOperationException ("Aynı isimde baska bir kategori bulunuyor!");
        }

        public async Task DeleteCategory(Category category)
        {
           var result = _categoryRepository.GetByCategoryId(category.Id);
           if(result != null)
           {
               await _categoryRepository.DeleteCategory(category);
           }
           throw new Exception("Silinecek kategori bulunamadi!");
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var updatedCategory = await _categoryRepository.GetByCategoryId(id);
            if(updatedCategory != null)
            {
                updatedCategory = category;
                await _categoryRepository.UpdateCategory(category);
                return category;
            }
            throw new InvalidOperationException("Guncellenecek kategori bulunamadi!");
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category> GetByCategoryId(int categoryId)
        {
            return await _categoryRepository.GetByCategoryId(categoryId);
        }

        public async Task<Category> GetByCategoryName(string categoryName)
        {
            return await _categoryRepository.GetByCategoryName(categoryName);
        }

        public async Task<List<Category>> GetSubCategoriesByCategoryName(string categoryName)
        {
            return await _categoryRepository.GetSubCategoriesByCategoryName(categoryName);
        }


    }
}
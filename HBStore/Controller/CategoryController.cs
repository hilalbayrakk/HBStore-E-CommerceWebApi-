using HBStore.Model;
using Microsoft.AspNetCore.Mvc;
using HBStore.Interface;


namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task<Category> Add (Category category)
        {
            await _categoryService.AddCategory(category);
            return category;
        }

        [HttpPut("delete")]
        public async Task Delete(Category category)
        {
            await _categoryService.DeleteCategory(category);
        }

        [HttpPut("update")]
        public async Task<Category> UpdateCategory([FromQuery]int id, Category category)
        {
            var result = await _categoryService.UpdateCategory(id, category);
            return result;
        }

        [HttpGet("getall")]
        public async Task<List<Category>> GetAll()
        {
            return await _categoryService.GetAllCategory();
        }

        [HttpGet("getbycategoryname")]
        public async Task<Category> GetByCategoryName(string categoryName)
        {
            return await _categoryService.GetByCategoryName(categoryName);
        }

        [HttpGet("getbycategoryid")]
        public async Task<Category> GetByCategoryId([FromQuery]int categoryId)
        {
            return await _categoryService.GetByCategoryId(categoryId);
        }

        [HttpGet("getsubcategories")]
        public async Task<List<Category>> GetSubCategoriesByCategoryName([FromQuery]string categoryName)
        {
            return await _categoryService.GetSubCategoriesByCategoryName(categoryName);
        }












        




    }

}
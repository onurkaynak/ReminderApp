
public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategories();
    Task<CategoryDTO> GetCategoryById(int id);
    Task<CategoryDTO> GetCategoryByName(string name);
    Task<CategoryDTO> UpdateCategoryById(Category category);
    Task<CategoryDTO> UpdateCategoryNameById(int id,string name);
    Task<CategoryDTO> CreateCategory(Category category);
    Task<CategoryDTO> DeleteCategoryByName(string name);
    Task<CategoryDTO> DeleteCategoryById(int id);
}
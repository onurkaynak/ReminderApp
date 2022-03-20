
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> GetCategoryByName(string name);
    Task<Category> UpdateCategoryById(Category category);
    Task<Category> UpdateCategoryNameById(int id,string name);
    Task<Category> CreateCategory(Category category);
    Task<Category> DeleteCategoryByName(string name);
    Task<Category> DeleteCategoryById(int id);

}
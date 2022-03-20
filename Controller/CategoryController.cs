
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService=categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
    {
        return await _categoryService.GetAllCategories();
    }

    [HttpGet("{id}")]
    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        return await _categoryService.GetCategoryById(id);
    }

    [HttpGet("name")]
    public async Task<CategoryDTO> GetCategoryByName(string name)
    {
        return await _categoryService.GetCategoryByName(name);
    }

    [HttpPut("{id}")]
    public async Task<CategoryDTO> UpdateCategoryById(Category category)
    {
        return await _categoryService.UpdateCategoryById(category);
    }

    [HttpPut("{idName}")]
    public async Task<CategoryDTO> UpdateCategoryNameById(int id,string name)
    {
        return await _categoryService.UpdateCategoryNameById(id,name);
    }

    [HttpPost]
    public async Task<CategoryDTO> CreateCategory(Category category)
    {
        return await _categoryService.CreateCategory(category);
    }

    [HttpDelete("name")]
    public async Task<CategoryDTO> DeleteCategoryByName(string name)
    {
        return await _categoryService.DeleteCategoryByName(name);
    }

    [HttpDelete("{id}")]
    public async Task<CategoryDTO> DeleteCategoryById(int id)
    {
        return await _categoryService.DeleteCategoryById(id);
    }
}
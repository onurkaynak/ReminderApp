
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository=categoryRepository;
    }


    async Task<CategoryDTO> ICategoryService.CreateCategory(Category category)
    {
       try
        {
            Category Category = await _categoryRepository.GetCategoryById(category.Id);
            if (Category == null)
            {
                return new CategoryDTO(await _categoryRepository.CreateCategory(category));
            }
            return new CategoryDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.DeleteCategoryById(int id)
    {
        try
        {
            Category Category = await _categoryRepository.GetCategoryById(id);
            if (Category != null)
            {
                return new CategoryDTO(await _categoryRepository.DeleteCategoryById(id));
            }
            return new CategoryDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.DeleteCategoryByName(string name)
    {
        try
        {
            Category Category = await _categoryRepository.GetCategoryByName(name);
            if (Category != null)
            {
                return new CategoryDTO(await _categoryRepository.DeleteCategoryByName(name));
            }
            return new CategoryDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<CategoryDTO>> ICategoryService.GetAllCategories()
    {
        try
        {
            IEnumerable<CategoryDTO> categoryDTOs = CategoryToCategoryDTO(await _categoryRepository.GetAllCategories());
            if (categoryDTOs != null)
            {
                return categoryDTOs;
            }
            return new List<CategoryDTO> { new CategoryDTO() };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.GetCategoryById(int id)
    {
       try
        {
            CategoryDTO categoryDTO = new CategoryDTO(await _categoryRepository.GetCategoryById(id));
            if(categoryDTO!=null)
            {
                return categoryDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.GetCategoryByName(string name)
    {
        try
        {
            CategoryDTO categoryDTO = new CategoryDTO(await _categoryRepository.GetCategoryByName(name));
            if(categoryDTO!=null)
            {
                return categoryDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.UpdateCategoryById(Category category)
    {
        try
        {
            CategoryDTO categoryDTO = new CategoryDTO(await _categoryRepository.GetCategoryById(category.Id));
            if(categoryDTO!=null)
            {
                return new CategoryDTO(await _categoryRepository.UpdateCategoryById(category));
            }
            return null;           
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<CategoryDTO> ICategoryService.UpdateCategoryNameById(int id, string name)
    {
        try
        {
            CategoryDTO categoryDTO = new CategoryDTO(await _categoryRepository.GetCategoryById(id));
            if(categoryDTO!=null)
            {
                return new CategoryDTO(await _categoryRepository.UpdateCategoryNameById(id,name));
            }
            return null;           
        }
        catch(Exception e)
        {
            return null;
        }
    }

    public IEnumerable<CategoryDTO> CategoryToCategoryDTO(IEnumerable<Category> categories)
    {   //TODO degisecek
        List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
        foreach (Category item in categories)
        {
            categoryDTOs.Add(new CategoryDTO(item));
        }
        return categoryDTOs;
    }
}
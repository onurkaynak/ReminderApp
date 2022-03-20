
public class CategoryRepository : ICategoryRepository
{

    private readonly ReminderContext _context;
    public CategoryRepository(ReminderContext remindercontext)
    {
        _context = remindercontext;
    }

    async Task<Category> ICategoryRepository.CreateCategory(Category category)
    {
        _context.Categories.Attach(category).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return category;
    }

    async Task<Category> ICategoryRepository.DeleteCategoryById(int id)
    {
        Category category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    async Task<Category> ICategoryRepository.DeleteCategoryByName(string name)
    {
        Category category = await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    async Task<IEnumerable<Category>> ICategoryRepository.GetAllCategories()
    {
        List<Category> temp = await (from ac in _context.Categories select ac).ToListAsync();
        return temp;
    }

    async Task<Category> ICategoryRepository.GetCategoryById(int id)
    {
        Category category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            return category;
        }
        return null;
    }

    async Task<Category> ICategoryRepository.GetCategoryByName(string name)
    {
        Category category = await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);
        if (category != null)
        {
            return category;
        }
        return null;
    }

    async Task<Category> ICategoryRepository.UpdateCategoryById(Category category)
    {
        Category Category = await _context.Categories.SingleOrDefaultAsync(x => x.Id==category.Id);
        if(Category!=null)
        {
            Category.Name=category.Name;
            Category.Tasks=category.Tasks;

            await _context.SaveChangesAsync();
            return Category;
        }
        return null;
    }

    async Task<Category> ICategoryRepository.UpdateCategoryNameById(int id,string name)
    {
        Category Category = await _context.Categories.SingleOrDefaultAsync(x => x.Id==id);
        if(Category!=null)
        {
            Category.Name=name;
            await _context.SaveChangesAsync();
            return Category;
        }
        return null;
    }
}
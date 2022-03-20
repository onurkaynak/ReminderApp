[Serializable]
public class CategoryDTO
{
    public string Name { get; set; }
    public virtual ICollection<Tasks> Tasks { get; set; }

    public CategoryDTO()
    {

    }
    public CategoryDTO(Category category)
    {
        this.Name=Name;
        this.Tasks=Tasks;
    }
}
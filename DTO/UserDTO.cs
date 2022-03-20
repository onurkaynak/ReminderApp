[Serializable]
public class UserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender? Gender { get; set; }
    public virtual ICollection<Tasks>? Tasks { get; set; } 

public UserDTO()
{

}

public UserDTO(User user)
{
    this.Name=Name;
    this.Surname=Surname;
    this.PhoneNumber=PhoneNumber;
    this.Gender=Gender;
    this.Tasks=Tasks;
    
}

}
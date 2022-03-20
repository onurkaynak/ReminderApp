public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public Gender? Gender { get; set; }
    public ICollection<Tasks>? Tasks { get; set; } 
    public int AccountId { get; set; }  
    public Account Account { get; set; }    


    public User()
    {

    }

    public User(User user)
    {
        this.Id=user.Id;
        this.Name= user.Name;
        this.Surname= user.Surname;
        this.PhoneNumber = user.Surname;
        this.Gender= user.Gender;
        this.Tasks =user.Tasks;
        this.Account= user.Account;
    }

    
}
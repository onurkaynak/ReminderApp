using System.Text.Json.Serialization;
public class Account
{
    public int Id { get; set; }
    public string Email { get; set; }
    public bool IsVisibility { get; set; }
    public User? User { get; set; }

    [JsonIgnore]
    public int Password { get; set; }


    public Account()
    {

    }

    public Account(Account account)
    {
        this.Id = account.Id;
        this.Email =account.Email;
        this.Password = account.Password;
        this.IsVisibility = account.IsVisibility;
        this.User = account.User;
        
    }


}
[Serializable]
public class AccountDTO
{
    public string Email { get; set; }
     public int Password { get; set; }
    public bool IsVisibility { get; set; }

    public AccountDTO() 
    {
        
    }
    public AccountDTO(Account account) 
    {
        this.Email = account.Email;
        this.Password = account.Password;
        this.IsVisibility = account.IsVisibility;
    }
}
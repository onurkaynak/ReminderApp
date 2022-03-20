public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int Password { get; set; }
    public bool IsVisibility { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(Account account, string token)
    {
        Id = account.Id;
        Email = account.Email;
        Password=account.Password;
        IsVisibility=account.IsVisibility;
        Token = token;
    }
}



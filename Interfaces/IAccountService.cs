
public interface IAccountService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<IEnumerable<AccountDTO>> GetAllAccounts();
    Task<AccountDTO> GetAccountByEmail(string email);
    Task<AccountDTO> GetAccountById(int id);
    Task<AccountDTO> GetAccountByUser(User user);

    Task<AccountDTO> CreateAccount(Account account);

    Task<AccountDTO> UpdateAccountByEmail(Account account);
    Task<AccountDTO> UpdatePasswordbyEmail(string email,int newpassword);
    Task<AccountDTO> ChangeVisibilityOfAccount(int id); 

}
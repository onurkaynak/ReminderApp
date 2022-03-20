public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<Account> GetAccountByEmail(string email);
    Task<Account> GetAccountById(int id);
    Task<Account> GetAccountByUser(User user);
    Task<Account> CreateAccount(Account account);
    Task<Account> UpdateAccountByEmail(Account account);
    Task<Account> UpdatePasswordbyEmail(string email,int newpassword); 
    Task<Account> ChangeVisibilityOfAccount(int id);

}
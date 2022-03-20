using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository=accountRepository;
    }

    private List<Account> _accounts = new List<Account>
    {
        new Account { Id = 1, Email="test", IsVisibility=true, Password =1,}
    };

    private readonly AppSettings _appSettings;

    public AccountService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var account = _accounts.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password); 

        // return null if user not found
        if (account == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(account);

        return new AuthenticateResponse(account, token);
    }

    private string generateJwtToken(Account account)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    async Task<AccountDTO> IAccountService.ChangeVisibilityOfAccount(int id)
    {
        try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountById(id));
            if (accountDTO != null)
            {
                return new AccountDTO(await _accountRepository.ChangeVisibilityOfAccount(id));
            }
            return new AccountDTO();
        }
        catch (Exception ex)
        {         
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.CreateAccount(Account account)
    {
        try
        {
            Account accountResponse = await _accountRepository.GetAccountByEmail(account.Email);
            if (accountResponse == null)
            {
                return new AccountDTO(await _accountRepository.CreateAccount(account));
            }
            return new AccountDTO();   
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.GetAccountByEmail(string email)
    {
         try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountByEmail(email));
            if (accountDTO != null)
            {
                return accountDTO;
            }
            return new AccountDTO();               
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.GetAccountById(int id)
    {
         try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountById(id));
            if (accountDTO != null)
            {
                return accountDTO;
            }
            return null;               
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.GetAccountByUser(User user)
    {
        try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountByUser(user));
            if (accountDTO != null)
            {
                return accountDTO;
            }
            return null;               
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<IEnumerable<AccountDTO>> IAccountService.GetAllAccounts()        
    {
        try
        {
            IEnumerable<AccountDTO> accountDTOs = AccountToAccountDTO(await _accountRepository.GetAllAccounts());
            if (accountDTOs != null)
            {
                return accountDTOs;
            }
            return new List<AccountDTO> { new AccountDTO() };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.UpdateAccountByEmail(Account account)
    {
        try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountByEmail(account.Email));
            if (accountDTO != null)
            {
                return new AccountDTO(await _accountRepository.UpdateAccountByEmail(account));
            }
            return new AccountDTO();
        }
        catch (Exception ex)
        {            
            return null;
        }
    }

    async Task<AccountDTO> IAccountService.UpdatePasswordbyEmail(string email, int newpassword)
    {
        try
        {
            AccountDTO accountDTO = new AccountDTO(await _accountRepository.GetAccountByEmail(email));
            if (accountDTO != null)
            {
                return new AccountDTO(await _accountRepository.UpdatePasswordbyEmail(email, newpassword));
            }
            return new AccountDTO();
        }
        catch (Exception ex)
        {            
            return null;
        }
    }


    public IEnumerable<AccountDTO> AccountToAccountDTO(IEnumerable<Account> accounts)
    {   
        List<AccountDTO> accountDTOs = new List<AccountDTO>();
        foreach (Account item in accounts)
        {
            accountDTOs.Add(new AccountDTO(item));
        }
        return accountDTOs;
    }

}
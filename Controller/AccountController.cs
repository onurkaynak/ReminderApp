using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
    {         
        return await _accountService.GetAllAccounts();
    }

    [HttpGet("email")]
    public async Task<AccountDTO> GetAccountByEmail(string email)
    {
        return await _accountService.GetAccountByEmail(email);
    }

    [HttpGet("{id}")]
    public async Task<AccountDTO> GetAccountById(int id)
    {
        return await _accountService.GetAccountById(id);
    }

    [HttpGet("user")]
    public async Task<AccountDTO> GetAccountByUser(User user)
    {
        return await _accountService.GetAccountByUser(user);
    }

    [HttpPost]
    public async Task<AccountDTO> CreateAccount(Account account)
    {
        return await _accountService.CreateAccount(account);
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _accountService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPut("email")]
    public async Task<AccountDTO> UpdateAccountByEmail(Account account)
    {
        return await _accountService.UpdateAccountByEmail(account);
    }

    [HttpPut("psw")]
    public async Task<AccountDTO> UpdatePasswordByEmail(string email, int newpassword)
    {
        return await _accountService.UpdatePasswordbyEmail(email , newpassword);
    }

    [HttpPut("{id}")]
    public async Task<AccountDTO> ChangeVisibilityOfAccount(int id)
    {
        return await _accountService.ChangeVisibilityOfAccount(id);
    }


}

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userservice;
    public UserController(IUserService userService)
    {
        _userservice=userService;
    }

    [HttpPost]
    public async Task<UserDTO> CreateUser(User user)
    {
        return await _userservice.CreateUser(user);
    }

    [HttpGet]
    public async Task<IEnumerable<UserDTO>> GetAllUser()
    {
        return await _userservice.GetAllUser();
    }

    [HttpGet("{accountId}")]
    public async Task<UserDTO> GetUserbyAccountId(int accountId)
    {
        return await _userservice.GetUserByAccountId(accountId);
    }

    [HttpGet("gender")]
    public async Task<IEnumerable<UserDTO>> GetUserByGender(Gender gender)
    {
        return await _userservice.GetUserByGender(gender);
    }

    [HttpGet("name")]
    public async Task<UserDTO> GetUserByName(string name)
    {
        return await _userservice.GetUserByName(name);
    }

    [HttpGet("phoneNumber")]
    public async Task<UserDTO> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _userservice.GetUserByPhoneNumber(phoneNumber);
    }

    [HttpGet("task")]
    public async Task<UserDTO> GetUserByTask(Tasks task)
    {
        return await _userservice.GetUserByTask(task);
    }

    [HttpPut("phoneNumber")]
    public async Task<UserDTO> UpdateUserbyPhoneNumber(User user)
    {
        return await _userservice.UpdateUserbyPhoneNumber(user);
    }
}
public class UserService : IUserService
{
    private readonly IUserRepository _userrepository;
    public UserService(IUserRepository userRepository)
    {
        _userrepository = userRepository;
    }
    async Task<UserDTO> IUserService.CreateUser(User user)
    {
        try
        {
            User User = await _userrepository.GetUserByPhoneNumber(user.PhoneNumber);
            if (User == null)
            {
                return new UserDTO(await _userrepository.CreateUser(user));
            }
            return new UserDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }
    async Task<IEnumerable<UserDTO>> IUserService.GetAllUser()
    {
        try
        {
            IEnumerable<UserDTO> userDTOs = UsertoUserDTO(await _userrepository.GetAllUser());
            if (userDTOs != null)
            {
                return userDTOs;
            }
            return new List<UserDTO> { new UserDTO() };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<UserDTO> IUserService.GetUserByAccountId(int accountId)
    {
        try
        {
            UserDTO userDTO = new UserDTO(await _userrepository.GetUserByAccountId(accountId));
            if (userDTO != null)
            {
                return userDTO;
            }
            return null;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<UserDTO>> IUserService.GetUserByGender(Gender gender)
    {
        try
        {
            IEnumerable<UserDTO> userDTOs = UsertoUserDTO(await _userrepository.GetUserByGender(gender));
            if (userDTOs != null)
            {
                return userDTOs;
            }
            return null;
        }
        catch (Exception e)
        {
            return null;
        }

    }

    async Task<UserDTO> IUserService.GetUserByName(string name)
    {
        try
        {
            UserDTO userDTO = new UserDTO(await _userrepository.GetUserByName(name));
            if(userDTO!=null)
            {
                return userDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<UserDTO> IUserService.GetUserByPhoneNumber(string phoneNumber)
    {
        try
        {
            UserDTO userDTO = new UserDTO(await _userrepository.GetUserByPhoneNumber(phoneNumber));
            if(userDTO!=null)
            {
                return userDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<UserDTO> IUserService.GetUserByTask(Tasks task)
    {
        try
        {
            UserDTO userDTO = new UserDTO(await _userrepository.GetUserByTask(task));
            if(userDTO!=null)
            {
                return userDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<UserDTO> IUserService.UpdateUserbyPhoneNumber(User user)
    {
        try
        {
            UserDTO userDTO = new UserDTO(await _userrepository.GetUserByPhoneNumber(user.PhoneNumber));
            if(userDTO!=null)
            {
                return new UserDTO(await _userrepository.UpdateUserbyPhoneNumber(user));
            }
            return null;           
        }
        catch(Exception e)
        {
            return null;
        }
    }
    public IEnumerable<UserDTO> UsertoUserDTO(IEnumerable<User> users)
    {   //TODO degisecek
        List<UserDTO> userDTOs = new List<UserDTO>();
        foreach (User item in users)
        {
            userDTOs.Add(new UserDTO(item));
        }
        return userDTOs;
    }
}
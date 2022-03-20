public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUser();
    Task<UserDTO> GetUserByName(string name);
    Task<UserDTO> GetUserByPhoneNumber(string phoneNumber);
    Task<IEnumerable<UserDTO>> GetUserByGender(Gender gender);
    Task<UserDTO> GetUserByTask(Tasks task);
    Task<UserDTO> GetUserByAccountId(int accountId);

    Task<UserDTO> CreateUser(User user);
    Task<UserDTO> UpdateUserbyPhoneNumber(User user);
    
}
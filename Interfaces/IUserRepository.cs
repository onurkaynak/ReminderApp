public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUser();
    Task<User> GetUserByName(string name);
    Task<User> GetUserByPhoneNumber(string phoneNumber);
    Task<IEnumerable<User>> GetUserByGender(Gender gender);
    Task<User> GetUserByTask(Tasks task);
    Task<User> GetUserByAccountId(int accountId);
    Task<User> CreateUser(User user);
    Task<User> UpdateUserbyPhoneNumber(User user);
    
    


}
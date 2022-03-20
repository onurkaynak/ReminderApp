public class UserRepository :IUserRepository
{
    private readonly ReminderContext _context;
    public UserRepository(ReminderContext reminderContext)
    {
        _context=reminderContext; 
    }

    async Task<User> IUserRepository.CreateUser(User user)
    {
        _context.Users.Attach(user).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return user;
    }

    async Task<IEnumerable<User>> IUserRepository.GetAllUser()
    {
        List<User> temp = await (from ac in _context.Users select ac).ToListAsync();
        return temp;
    }

    async Task<User> IUserRepository.GetUserByAccountId(int accountId)
    {
        User? user = await (from ac in _context.Users
                              where ac.AccountId == accountId
                              select ac).FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        return null;
    }

    async Task<IEnumerable<User>> IUserRepository.GetUserByGender(Gender gender)
    {
        List<User> users = await (from us in _context.Users
                            where us.Gender==gender
                            select us).ToListAsync();
        return users;
    }

    async Task<User> IUserRepository.GetUserByName(string name)
    {
        User User= await _context.Users.SingleOrDefaultAsync(x=> x.Name==name);
        if(User!=null)
        {
            return User;
        }
        return null;
    }

    async Task<User> IUserRepository.GetUserByPhoneNumber(string phoneNumber)
    {
        User user= await _context.Users.SingleOrDefaultAsync(x=> x.PhoneNumber==phoneNumber);
        if(user!=null)
        {
            return user;    
        }
        return null;
    }

    async Task<User> IUserRepository.GetUserByTask(Tasks task)
    {
        User user =await _context.Users.SingleOrDefaultAsync(x=> x.Tasks==task);
        if(user!=null)
        {
            return user;
        }
        return null;
    }

    async Task<User> IUserRepository.UpdateUserbyPhoneNumber(User user)
    {
        User User =await _context.Users.SingleOrDefaultAsync(x=>x.PhoneNumber==user.PhoneNumber);
        if(User!=null)
        {
            User.Name=user.Name;
            User.Surname=user.Surname;
            User.PhoneNumber=user.PhoneNumber;
            User.Gender=user.Gender;
            User.Tasks=user.Tasks;
            
            await _context.SaveChangesAsync();
            return User;
        }
        return null;
    }

    
}
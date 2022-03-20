using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class AccountRepository : IAccountRepository
{

    private readonly ReminderContext _context;
    public AccountRepository(ReminderContext remindercontext)
    {
        _context = remindercontext;
    }

    async Task<Account> IAccountRepository.ChangeVisibilityOfAccount(int id)
    {
        Account? ac = await (_context.Accounts.SingleOrDefaultAsync(x => x.Id == id));
        ac.IsVisibility = !ac.IsVisibility;
        await _context.SaveChangesAsync();
        return ac;
    }

    async Task<Account> IAccountRepository.CreateAccount(Account account)
    {
        _context.Accounts.Attach(account).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return account;
    }

    async Task<Account> IAccountRepository.GetAccountByEmail(string email)
    {
        Account? acc =await _context.Accounts.SingleOrDefaultAsync(x => x.Email == email);
        if (acc != null)
        {
            return acc;
        }
        return null;
    }

    async Task<Account> IAccountRepository.GetAccountById(int id)
    {

        Account acc = await _context.Accounts.SingleOrDefaultAsync(x => x.Id == id);
        if (acc != null)
        {
            return acc;
        }
        return null;
    }

    async Task<Account> IAccountRepository.GetAccountByUser(User user)           // id ile getirilebilir
    {

        Account? acc = await _context.Accounts.SingleOrDefaultAsync(x=> x.User==user);
        if (acc != null)
        {
            return acc;
        }
        return null;

    }

    async Task<IEnumerable<Account>> IAccountRepository.GetAllAccounts()
    {
        List<Account> temp = await (from ac in _context.Accounts select ac).ToListAsync();
        return temp;
    }

    async Task<Account> IAccountRepository.UpdateAccountByEmail(Account account)
    {

        Account? ac = await _context.Accounts.SingleOrDefaultAsync(x => x.Email == account.Email);
        ac.Email = account.Email;
        ac.Password = account.Password;
        ac.IsVisibility = account.IsVisibility;
        await _context.SaveChangesAsync();                 // update kullanmadık
        return ac;
        

    }
    async Task<Account> IAccountRepository.UpdatePasswordbyEmail(string email, int newpassword)
    {

        Account? ac = await _context.Accounts.SingleOrDefaultAsync(x => x.Email == email);
        ac.Password = newpassword;
        await _context.SaveChangesAsync();
        return ac;


    }
}
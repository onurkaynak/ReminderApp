public class TasksRepository : ITasksRepository
{
    private readonly ReminderContext _context;
    public TasksRepository(ReminderContext reminderContext)
    {
        _context = reminderContext;
    }

    async Task<Tasks> ITasksRepository.CreateTask(Tasks task)
    {
        _context.Tasks.Attach(task).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return task;
    }

    async Task<Tasks> ITasksRepository.DeleteTaskById(int id)
    {
        Tasks task = await _context.Tasks.SingleOrDefaultAsync(x => x.Id == id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    async Task<Tasks> ITasksRepository.DeleteTaskByName(string name)
    {
        Tasks task = await _context.Tasks.SingleOrDefaultAsync(x => x.Name == name);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    async Task<IEnumerable<Tasks>> ITasksRepository.GetAllTasks()
    {
        List<Tasks> temp = await (from ac in _context.Tasks select ac).ToListAsync();
        return temp;
    }

    async Task<Tasks> ITasksRepository.GetTaskById(int id)
    {
        Tasks task = await _context.Tasks.SingleOrDefaultAsync(x => x.Id == id);
        if (task != null)
        {
            return task;
        }
        return null;
    }

    async Task<Tasks> ITasksRepository.GetTaskByName(string name)
    {
        Tasks task = await _context.Tasks.SingleOrDefaultAsync(x => x.Name == name);
        if (task != null)
        {
            return task;
        }
        return null;
    }

    async Task<IEnumerable<Tasks>> ITasksRepository.GetTasksByCategoryName(string categoryName)
    {
        List<Tasks> tasks = await (from us in _context.Tasks
                            where us.Category.Name==categoryName
                            select us).ToListAsync();
        return tasks;
    }

    async Task<IEnumerable<Tasks>> ITasksRepository.GetTasksByIsCompleted(bool IsCompleted)
    {
        List<Tasks> tasks = await (from us in _context.Tasks
                            where us.IsCompleted==IsCompleted
                            select us).ToListAsync();
        return tasks;
    }

    async Task<IEnumerable<Tasks>> ITasksRepository.GetTasksByUserId(int userId)
    {
        List<Tasks> tasks = await (from us in _context.Tasks
                            where us.UserId==userId
                            select us).ToListAsync();
        return tasks;
    }

    async Task<IEnumerable<Tasks>> ITasksRepository.GetTasksByUserPhoneNumber(string phoneNumber)
    {
        List<Tasks> tasks = await (from us in _context.Tasks
                            where us.User.PhoneNumber==phoneNumber
                            select us).ToListAsync();
        return tasks;
    }

    async Task<Tasks> ITasksRepository.UpdateTaskByName(Tasks task)
    {
        Tasks Task = await _context.Tasks.SingleOrDefaultAsync(x => x.Name==task.Name);
        if(Task!=null)
        {
            Task.Name=task.Name;
            Task.ReminderDate=task.ReminderDate;
            Task.IsCompleted=task.IsCompleted;
            Task.CategoryId=task.CategoryId;
            Task.UserId=task.UserId;
            await _context.SaveChangesAsync();
            return Task;
        }
        return null;

    }

    async Task<Tasks> ITasksRepository.UpdateTaskbyId(Tasks task)
    {
        Tasks Task = await _context.Tasks.SingleOrDefaultAsync(x => x.Id==task.Id);
        if(Task!=null)
        {
            Task.Name=task.Name;
            Task.ReminderDate=task.ReminderDate;
            Task.IsCompleted=task.IsCompleted;
            Task.CategoryId=task.CategoryId;
            Task.UserId=task.UserId;
            await _context.SaveChangesAsync();
            return Task;
        }
        return null;
    }
}
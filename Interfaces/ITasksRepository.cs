public interface ITasksRepository
{
    Task<IEnumerable<Tasks>> GetAllTasks();
    Task<Tasks> GetTaskById(int id);
    Task<Tasks> GetTaskByName(string name);
    Task<IEnumerable<Tasks>> GetTasksByIsCompleted(bool IsCompleted);
    Task<IEnumerable<Tasks>> GetTasksByCategoryName(string categoryName);
    Task<IEnumerable<Tasks>> GetTasksByUserId(int userId);
    Task<IEnumerable<Tasks>> GetTasksByUserPhoneNumber(string phoneNumber);

    Task<Tasks> CreateTask(Tasks task);
    Task<Tasks> UpdateTaskByName(Tasks task);
    Task<Tasks> UpdateTaskbyId(Tasks task);
    Task<Tasks>  DeleteTaskByName(string name);
    Task<Tasks> DeleteTaskById(int id);
    
 
}

public interface ITasksService
{
    Task<IEnumerable<TasksDTO>> GetAllTasks();
    Task<TasksDTO> GetTaskById(int id);
    Task<TasksDTO> GetTaskByName(string name);
    Task<IEnumerable<TasksDTO>> GetTasksByIsCompleted(bool IsCompleted);
    Task<IEnumerable<TasksDTO>> GetTasksByCategoryName(string categoryName);
    Task<IEnumerable<TasksDTO>> GetTasksByUserId(int userId);
    Task<IEnumerable<TasksDTO>> GetTasksByUserPhoneNumber(string phoneNumber);

    Task<TasksDTO> CreateTask(Tasks task);
    Task<TasksDTO> UpdateTaskByName(Tasks task);
    Task<TasksDTO> UpdateTaskbyId(Tasks task);
    Task<TasksDTO> DeleteTaskByName(string name);
    Task<TasksDTO> DeleteTaskById(int id);
}
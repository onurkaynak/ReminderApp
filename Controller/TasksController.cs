
[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private ITasksService _taskService;
    public TasksController(ITasksService tasksService)
    {
        _taskService= tasksService;
    }

    [HttpGet]
    public async Task<IEnumerable<TasksDTO>> GetAllTasks()
    {
        return await _taskService.GetAllTasks();
    }

    [HttpGet("{id}")]
    public async Task<TasksDTO> GetTasksById(int id)
    {
        return await _taskService.GetTaskById(id);
    }

    [HttpGet("name")]
    public async Task<TasksDTO> GetTasksByName(string name)
    {
        return await _taskService.GetTaskByName(name);
    }

    [HttpGet("iscompleted")]
    public async Task<IEnumerable<TasksDTO>> GetTasksByIsCompleted(bool IsCompleted)
    {
        return await _taskService.GetTasksByIsCompleted(IsCompleted);
    }

    [HttpGet("category")]
    public async Task<IEnumerable<TasksDTO>> GetTasksByCategoryName(string categoryName)
    {
        return await _taskService.GetTasksByCategoryName(categoryName);
    }

    [HttpGet("userId")]
    public async Task<IEnumerable<TasksDTO>> GetTasksByUserId(int userId)
    {
        return await _taskService.GetTasksByUserId(userId);
    }

    [HttpGet("phoneNumber")]
    public async Task<IEnumerable<TasksDTO>> GetTasksByUserPhoneNumber(string phoneNumber)
    {
        return await _taskService.GetTasksByUserPhoneNumber(phoneNumber);
    }

    [HttpPost]
    public async Task<TasksDTO> CreateTask(Tasks task)
    {
        return await _taskService.CreateTask(task);
    }

    [HttpPut("name")]
    public async Task<TasksDTO> UpdateTaskByName(Tasks task)
    {
        return await _taskService.UpdateTaskByName(task);
    }

    [HttpPut("{id}")]
    public async Task<TasksDTO> UpdateTaskbyId(Tasks task)
    {
        return await _taskService.UpdateTaskbyId(task);
    }

    [HttpDelete("name")]
    public async Task<TasksDTO> DeleteTaskByName(string name)
    {
        return await _taskService.DeleteTaskByName(name);
    }

    [HttpDelete("{id}")]
    public async Task<TasksDTO> DeleteTaskById(int id)
    {
        return await _taskService.DeleteTaskById(id);
    }
}
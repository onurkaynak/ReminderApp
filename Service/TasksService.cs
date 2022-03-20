public class TasksService : ITasksService
{
    private readonly ITasksRepository _tasksRepository;
    public TasksService(ITasksRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    async Task<TasksDTO> ITasksService.CreateTask(Tasks task)
    {
        try
        {
            Tasks Task = await _tasksRepository.GetTaskById(task.Id);
            if (Task == null)
            {
                return new TasksDTO(await _tasksRepository.CreateTask(task));
            }
            return new TasksDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<TasksDTO> ITasksService.DeleteTaskById(int id)
    {
        try
        {
            Tasks Task = await _tasksRepository.GetTaskById(id);
            if (Task != null)
            {
                return new TasksDTO(await _tasksRepository.DeleteTaskById(id));
            }
            return new TasksDTO();
        }
        catch (Exception e)
        {
            return null;
        }

    }

    async Task<TasksDTO> ITasksService.DeleteTaskByName(string name)
    {
        try
        {
            Tasks Task = await _tasksRepository.GetTaskByName(name);
            if (Task != null)
            {
                return new TasksDTO(await _tasksRepository.DeleteTaskByName(name));
            }
            return new TasksDTO();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<TasksDTO>> ITasksService.GetAllTasks()
    {
        try
        {
            IEnumerable<TasksDTO> tasksDTOs = TaskstoTasksDTO(await _tasksRepository.GetAllTasks());
            if (tasksDTOs != null)
            {
                return tasksDTOs;
            }
            return new List<TasksDTO> { new TasksDTO() };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    async Task<TasksDTO> ITasksService.GetTaskById(int id)
    {
        try
        {
            TasksDTO tasksDTO = new TasksDTO(await _tasksRepository.GetTaskById(id));
            if(tasksDTO!=null)
            {
                return tasksDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<TasksDTO> ITasksService.GetTaskByName(string name)
    {
        try
        {
            TasksDTO tasksDTO = new TasksDTO(await _tasksRepository.GetTaskByName(name));
            if(tasksDTO!=null)
            {
                return tasksDTO;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<TasksDTO>> ITasksService.GetTasksByCategoryName(string categoryName)
    {
        try
        {
            IEnumerable<TasksDTO> tasksDTOs = TaskstoTasksDTO(await _tasksRepository.GetTasksByCategoryName(categoryName));
            if(tasksDTOs!=null)
            {
                return tasksDTOs;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<TasksDTO>> ITasksService.GetTasksByIsCompleted(bool IsCompleted)
    {
        try
        {
            IEnumerable<TasksDTO> tasksDTOs = TaskstoTasksDTO(await _tasksRepository.GetTasksByIsCompleted(IsCompleted));
            if(tasksDTOs!=null)
            {
                return tasksDTOs;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<TasksDTO>> ITasksService.GetTasksByUserId(int userId)
    {
        try
        {
            IEnumerable<TasksDTO> tasksDTOs = TaskstoTasksDTO(await _tasksRepository.GetTasksByUserId(userId));
            if(tasksDTOs!=null)
            {
                return tasksDTOs;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<IEnumerable<TasksDTO>> ITasksService.GetTasksByUserPhoneNumber(string phoneNumber)
    {
        try
        {
            IEnumerable<TasksDTO> tasksDTOs = TaskstoTasksDTO(await _tasksRepository.GetTasksByUserPhoneNumber(phoneNumber));
            if(tasksDTOs!=null)
            {
                return tasksDTOs;
            }
            return null;
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<TasksDTO> ITasksService.UpdateTaskbyId(Tasks task)
    {
        try
        {
            TasksDTO tasksDTO = new TasksDTO(await _tasksRepository.GetTaskById(task.Id));
            if(tasksDTO!=null)
            {
                return new TasksDTO(await _tasksRepository.UpdateTaskbyId(task));
            }
            return null;           
        }
        catch(Exception e)
        {
            return null;
        }
    }

    async Task<TasksDTO> ITasksService.UpdateTaskByName(Tasks task)
    {
        try
        {
            TasksDTO tasksDTO = new TasksDTO(await _tasksRepository.GetTaskByName(task.Name));
            if(tasksDTO!=null)
            {
                return new TasksDTO(await _tasksRepository.UpdateTaskByName(task));
            }
            return null;           
        }
        catch(Exception e)
        {
            return null;
        }
    }

    public IEnumerable<TasksDTO> TaskstoTasksDTO(IEnumerable<Tasks> tasks)
    {   //TODO degisecek
        List<TasksDTO> tasksDTOs = new List<TasksDTO>();
        foreach (Tasks item in tasks)
        {
            tasksDTOs.Add(new TasksDTO(item));
        }
        return tasksDTOs;
    }
}
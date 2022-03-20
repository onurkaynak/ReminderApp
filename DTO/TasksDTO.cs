[Serializable]
public class TasksDTO
{
    public string Name { get; set; }
    public DateTime ReminderDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public HowOften? HowOften { get; set; }
    public bool IsCompleted { get; set; }
    public Category? Category { get; set; }
    public User User { get; set; }

    public TasksDTO()
    {

    }
    public TasksDTO(Tasks tasks)
    {
        this.Name=Name;
        this.ReminderDate=ReminderDate;
        this.ExpirationDate=ExpirationDate;
        this.HowOften=HowOften;
        this.IsCompleted=IsCompleted;
        this.Category=Category;
        this.User=User;
    }
}


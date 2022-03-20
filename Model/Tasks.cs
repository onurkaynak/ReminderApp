public class Tasks
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public DateTime ReminderDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public HowOften? HowOften { get; set; }
    public bool IsCompleted { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

}
public class TasksDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
       
    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e=> e.ReminderDate).IsRequired();
            entity.Property(e=> e.ExpirationDate);
            entity.Property(e=> e.HowOften);
            entity.Property(e=> e.IsCompleted);
            entity.HasOne(b => b.Category).WithMany(i => i.Tasks).HasForeignKey(b=> b.CategoryId);

            

        });
    }
}
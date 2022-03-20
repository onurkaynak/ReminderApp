public class UserDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
       
    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e=> e.Surname).IsRequired();
            entity.Property(e=> e.PhoneNumber);
            entity.Property(e=> e.Gender);
            entity.HasMany(e=>e.Tasks).WithOne(r=>r.User).HasForeignKey(e=> e.UserId);
            
            

        });

    }
}
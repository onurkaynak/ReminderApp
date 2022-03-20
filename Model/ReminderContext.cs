public class ReminderContext:DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Tasks>? Tasks { get; set; }
    public DbSet<Category>? Categories { get; set; }



     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        optionsBuilder.UseMySql("server=localhost;database=sahabt;user=root;port=3306;password=toortoor", serverVersion);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AccountDatabaseBuilder.TableBuilder(modelBuilder);
        UserDatabaseBuilder.TableBuilder(modelBuilder);
        CategoryDatabaseBuilder.TableBuilder(modelBuilder);
        TasksDatabaseBuilder.TableBuilder(modelBuilder);
        
    }


}
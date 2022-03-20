public class CategoryDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
       
    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasMany(e=> e.Tasks).WithOne(e=> e.Category).HasForeignKey(e=> e.CategoryId);
        });

    }
}
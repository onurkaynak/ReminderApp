public class AccountDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
       
    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e=> e.Password).IsRequired();
            entity.Property(e=>e.IsVisibility);
            entity.HasOne(b => b.User).WithOne(i => i.Account).HasForeignKey<User>(b => b.AccountId);

            //entity.HasOne(e=>e.Address).WithMany(r=>r.Suppliers).HasForeignKey(i=>i.AddressId);
        });
    }
}
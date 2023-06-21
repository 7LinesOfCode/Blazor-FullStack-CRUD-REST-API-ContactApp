namespace ContactsCRUD.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category { Id = 1, Name = "Private" },
                new Category { Id = 2, Name = "Work" },
                new Category { Id = 3, Name = "Other" }
            );
            modelBuilder.Entity<Contact>().HasData
            (
            new Contact
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Brzechwa",
                PhoneNumber = "123 123 123",
                Note = "",
                CategoryId = 1,
            },
            new Contact
            {
                Id = 2,
                FirstName = "Net",
                LastName = "Pc",
                PhoneNumber = "123 123 123",
                Note = "",
                CategoryId = 2
            }
            );
        }

        public DbSet<Contact> Contacts { get; set;}
        public DbSet<Category> Categories { get; set; }
    }
}

using System.Data.Entity;

namespace DataLibrary
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Homework10"){}
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
using DataModel.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public  class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}

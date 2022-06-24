using crud_3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_3._0.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}

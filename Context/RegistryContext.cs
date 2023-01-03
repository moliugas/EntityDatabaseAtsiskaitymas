using EntityDB.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityDB.Context
{
    public class RegistryContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=MOLL\\SQLEXPRESS;Database=StudentRegistry;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

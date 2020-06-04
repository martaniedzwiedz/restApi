using Microsoft.EntityFrameworkCore;

namespace project_test.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Student> Students{get; set;}
        
    }
}
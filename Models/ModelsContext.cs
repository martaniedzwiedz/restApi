using Microsoft.EntityFrameworkCore;
using project_test.Models;

namespace restApi.Models
{
    public class ModelsContext :  DbContext
    { 
        public ModelsContext(DbContextOptions options) : base(options){}
        public virtual DbSet<UserEntity> Users{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(p => p.Id);
            });
        }
    }

    
}
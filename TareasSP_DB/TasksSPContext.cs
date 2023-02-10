using Microsoft.EntityFrameworkCore;

namespace TareasSP_DB
{
    public class TasksSPContext : DbContext
    {
        public TasksSPContext(DbContextOptions<TasksSPContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Task");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}

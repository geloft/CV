using CV.Models.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(e => e.User)
                .HasForeignKey(k => k.UserID);

            modelBuilder.Entity<User>().HasIndex(m => m.Email).IsUnique();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

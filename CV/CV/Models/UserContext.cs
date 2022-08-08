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

            modelBuilder.Entity<User>().Property(p => p.UserID).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();

            modelBuilder.Entity<Message>().Property(p => p.MessageId).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.Text).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.UserID).IsRequired();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

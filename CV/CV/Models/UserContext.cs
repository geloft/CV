using Microsoft.EntityFrameworkCore;

namespace CV.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(e => e.User)
                .HasForeignKey(k=> k.MessageId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

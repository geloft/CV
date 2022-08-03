using Microsoft.EntityFrameworkCore;

namespace CV.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyCV-DB;Trusted_Connection=True");
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

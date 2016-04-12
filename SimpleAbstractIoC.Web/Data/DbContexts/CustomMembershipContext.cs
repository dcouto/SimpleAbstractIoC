using System.Data.Entity;
using SimpleIoCContainerIoC.Domain.Data.Entities;

namespace SimpleAbstractIoC.Web.Data.DbContexts
{
    public class CustomMembershipContext : DbContext
    {
        public CustomMembershipContext() : base("name=custom_membership")
        {
        }

        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reminder>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reminders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

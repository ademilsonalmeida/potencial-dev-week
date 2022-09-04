using dev_week.src.Models;
using Microsoft.EntityFrameworkCore;

namespace dev_week.src.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(p => {
                p.HasKey(p => p.Id);

                p.HasMany(p => p.Contracts)
                 .WithOne()
                 .HasForeignKey(c => c.PersonId);
            });

            builder.Entity<Contract>(c => {
                c.HasKey(c => c.Id);
            });
        }
    }
}
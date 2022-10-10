using Microsoft.EntityFrameworkCore;

namespace DinoPoll.Data
{
    public class DinoPollContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DinoPollContext(DbContextOptions<DinoPollContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>()
                .Property(option => option.Votes)
                .HasDefaultValue(0);

            base.OnModelCreating(modelBuilder);
        }
    }
}

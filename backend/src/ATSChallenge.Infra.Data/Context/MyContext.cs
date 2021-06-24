using Microsoft.EntityFrameworkCore;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Infra.Data.Mapping;

namespace ATSChallenge.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<LogEntity> Logs { get; set; }

        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LogEntity>(new LogMap().Configure);
            modelBuilder.Entity<JobEntity>(new JobMap().Configure);
        }
    }
}

using System;
using System.Threading.Tasks;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Domain.Interfaces.Repositories;
using ATSChallenge.Infra.Data.Context;

namespace ATSChallenge.Infra.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly MyContext context;

        public LogRepository(MyContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(LogEntity entity)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();

            entity.CreateAt = DateTime.UtcNow;

            await context.Logs.AddAsync(entity);

            await context.SaveChangesAsync();
        }
    }
}

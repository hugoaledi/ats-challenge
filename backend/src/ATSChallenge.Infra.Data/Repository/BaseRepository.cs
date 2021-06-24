using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Domain.Interfaces;
using ATSChallenge.Infra.Data.Context;

namespace ATSChallenge.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext context;
        private DbSet<T> dataSet;

        public BaseRepository(MyContext context)
        {
            this.context = context;
            dataSet = this.context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.CreateAt = DateTime.UtcNow;

            await dataSet.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var dbEntity = await ReadAsync(entity.Id);
            if (dbEntity == null) return;

            entity.CreateAt = dbEntity.CreateAt;
            entity.UpdateAt = DateTime.UtcNow;

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await ReadAsync(id);
            if (entity == null) return;

            dataSet.Remove(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task<T> ReadAsync(Guid id)
        {
            return await dataSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<T>> ReadAsync()
        {
            return await dataSet.ToListAsync();
        }
    }
}

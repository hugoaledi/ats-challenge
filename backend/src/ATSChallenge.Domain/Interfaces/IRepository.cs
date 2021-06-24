using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATSChallenge.Domain.Entities;

namespace ATSChallenge.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);

        Task<T> ReadAsync(Guid id);

        Task<IEnumerable<T>> ReadAsync();
    }
}

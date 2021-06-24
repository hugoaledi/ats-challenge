using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATSChallenge.Domain.Models;

namespace ATSChallenge.Domain.Interfaces.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobModel>> GetAllAsync();

        Task<JobModel> GetAsync(Guid id);

        Task CreateAsync(JobModel model);

        Task UpdateAsync(Guid id, JobModel model);

        Task DeleteAsync(Guid id);
    }
}

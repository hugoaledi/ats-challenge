using ATSChallenge.Domain.Entities;
using ATSChallenge.Infra.Data.Context;
using ATSChallenge.Domain.Interfaces.Repositories;

namespace ATSChallenge.Infra.Data.Repository
{
    public class JobRepository : BaseRepository<JobEntity>, IJobRepository
    {
        public JobRepository(MyContext context) : base(context) { }
    }
}

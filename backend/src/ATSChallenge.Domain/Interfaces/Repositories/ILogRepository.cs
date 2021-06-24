using System.Threading.Tasks;
using ATSChallenge.Domain.Entities;

namespace ATSChallenge.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task CreateAsync(LogEntity entity);
    }
}

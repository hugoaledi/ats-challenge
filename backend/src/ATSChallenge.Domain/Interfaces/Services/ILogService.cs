using System;
using System.Threading.Tasks;

namespace ATSChallenge.Domain.Interfaces.Services
{
    public interface ILogService : IDisposable
    {
        Task CriarLogErro(string operacao, Exception exception);
    }
}

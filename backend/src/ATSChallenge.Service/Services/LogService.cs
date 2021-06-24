using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Domain.Interfaces.Services;
using ATSChallenge.Domain.Interfaces.Repositories;
using ATSChallenge.Domain.CustomExceptions;

namespace ATSChallenge.Service.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task CriarLogErro(string operacao, Exception exception)
        {
            var message = exception.Message ?? string.Empty;

            if (exception is NotFoundException)
            {
                var id = (exception as NotFoundException).Id;
                message += "Id: " + (!id.HasValue ? "null" : id.Value.ToString());
            }

            await logRepository.CreateAsync(new LogEntity
            {
                Tipo = "ERROR",
                Operacao = operacao,
                Mensagem = exception.Message,
                Exception = JsonConvert.SerializeObject(exception)
            });
        }

        public void Dispose() { }
    }
}

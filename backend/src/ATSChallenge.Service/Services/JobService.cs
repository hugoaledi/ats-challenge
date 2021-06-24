using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATSChallenge.Domain.CustomExceptions;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Domain.Interfaces.Repositories;
using ATSChallenge.Domain.Interfaces.Services;
using ATSChallenge.Domain.Models;
using AutoMapper;

namespace ATSChallenge.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobModel>> GetAllAsync() =>
            _mapper.Map<IEnumerable<JobModel>>(await _jobRepository.ReadAsync());

        public async Task<JobModel> GetAsync(Guid id) =>
            _mapper.Map<JobModel>(await _jobRepository.ReadAsync(id));

        public async Task CreateAsync(JobModel model)
        {
            var entity = _mapper.Map<JobEntity>(model);

            await _jobRepository.CreateAsync(entity);

            model.Id = entity.Id;
        }

        public async Task UpdateAsync(Guid id, JobModel model)
        {
            var entity = await _jobRepository.ReadAsync(id);

            if (entity == null) throw new NotFoundException("Vaga não encontrada");

            entity.Title = model.Title;
            entity.Description = model.Description;

            await _jobRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _jobRepository.DeleteAsync(id);
        }
    }
}

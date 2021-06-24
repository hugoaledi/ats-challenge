using AutoMapper;
using ATSChallenge.Domain.Entities;
using ATSChallenge.Domain.Models;

namespace ATSChallenge.Infra.CrossCutting.Mappings
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<JobEntity, JobModel>().ReverseMap();
        }
    }
}

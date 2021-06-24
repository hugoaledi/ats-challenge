using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ATSChallenge.Domain.Interfaces.Services;
using ATSChallenge.Domain.Models;
using System;
using System.Linq;

namespace ATSChallenge.Application.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobsController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get() =>
            Ok((await _jobService.GetAllAsync()).OrderBy(job => job.Title));

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id) =>
            Ok(await _jobService.GetAsync(id));

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobModel model)
        {
            await _jobService.CreateAsync(model);

            return Ok(model);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] JobModel model)
        {
            await _jobService.UpdateAsync(id, model);

            return Ok(model);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _jobService.DeleteAsync(id);

            return Ok();
        }
    }
}

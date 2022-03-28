using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.ViewModels;
using System;
using System.Threading.Tasks;

namespace NOUS_challenge_app.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CleaningPlanController : GenericController<CleaningPlanModel>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CleaningPlanController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/createCleaningPlan")]
        public async Task<CleaningPlanViewModel> CreateCleaningPlan([FromBody] CleaningPlanModel model)
        {
            var command = new CleaningPlanCreateRequest(model);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                throw new Exception(
                    "Unfortunately, something went wrong. Please, check your data for correctness.");
            }
            var viewModel = _mapper.Map<CleaningPlanViewModel>(result);
            return viewModel;
        }

        [HttpPut]
        [Route("/editCleaningPlan")]
        public async Task<CleaningPlanViewModel> EditCleaningPlan([FromBody] CleaningPlanModel model)
        {
            var command = new CleaningPlanUpdateRequest(model);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                throw new Exception(
                    "Unfortunately, something went wrong. Please, check your data for correctness.");
            }
            var viewModel = _mapper.Map<CleaningPlanViewModel>(result);
            return viewModel;
        }
    }
}

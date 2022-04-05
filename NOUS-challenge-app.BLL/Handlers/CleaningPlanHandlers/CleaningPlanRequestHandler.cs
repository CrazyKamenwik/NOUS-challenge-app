using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;

namespace NOUS_challenge_app.BLL.Handlers.CleaningPlanHandlers
{
    public class CleaningPlanRequestHandler :
        IRequestHandler<CleaningPlanCreateRequest, CleaningPlanModel>,
        IRequestHandler<CleaningPlanUpdateRequest, CleaningPlanModel>
    {
        private readonly IGenericRepository<CleaningPlanEntity> _repository;
        private readonly IMapper _mapper;

        public CleaningPlanRequestHandler(IGenericRepository<CleaningPlanEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CleaningPlanModel> Handle(CleaningPlanCreateRequest request,
            CancellationToken cancellationToken)
        {
            var cleaningPlan = new CleaningPlanEntity
            {
                Title = request.Title,
                CreatedAt = DateTime.Now,
                CustomerId = request.CustomerId,
                Description = request.Description
            };
            var cleaningPlanEntity = await _repository.CreateAsync(cleaningPlan);
            var cleaningPlanModel = _mapper.Map<CleaningPlanModel>(cleaningPlanEntity);
            return cleaningPlanModel;
        }

        public async Task<CleaningPlanModel> Handle(CleaningPlanUpdateRequest request,
            CancellationToken cancellationToken)
        {
            var cleaningPlan = new CleaningPlanEntity
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = request.CreatedAt
            };
            var cleaningPlanEntity = await _repository.UpdateAsync(cleaningPlan);
            var cleaningPlanModel = _mapper.Map<CleaningPlanModel>(cleaningPlanEntity);
            return cleaningPlanModel;
        }
    }
}
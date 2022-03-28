using AutoMapper;
using MediatR;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.BLL.Requests.Generics;
using NOUS_challenge_app.DAL;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOUS_challenge_app.BLL.Handlers
{
    public class CleaningPlanRequestHandler<TModel> :
        IRequestHandler<GenericGetAllQuery<CleaningPlanModel>, IEnumerable<CleaningPlanModel>>,
        IRequestHandler<GenericGetByIdQuery<CleaningPlanModel>, CleaningPlanModel>,
        IRequestHandler<GenericGetByCustomerIdQuery<CleaningPlanModel>, List<CleaningPlanModel>>,
        IRequestHandler<GenericDeleteRequest<CleaningPlanModel>, Unit>,
        IRequestHandler<CleaningPlanCreateRequest, CleaningPlanModel>,
        IRequestHandler<CleaningPlanUpdateRequest, CleaningPlanModel>
    {
        private readonly IGenericRepository<CleaningPlanEntity> _repository;
        private readonly IMapper _mapper;

        public CleaningPlanRequestHandler(AppDbContext appDbContext, IGenericRepository<CleaningPlanEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CleaningPlanModel>> Handle(GenericGetAllQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetAllAsync();
            var cleaningPlanModel = _mapper.Map<IEnumerable<CleaningPlanModel>>(cleaningPlanEntity);
            return cleaningPlanModel;
        }

        public async Task<CleaningPlanModel> Handle(GenericGetByIdQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetByIdAsync(request.Id);
            var cleaningPlanModel = _mapper.Map<CleaningPlanModel>(cleaningPlanEntity);
            return cleaningPlanModel;
        }

        public async Task<List<CleaningPlanModel>> Handle(GenericGetByCustomerIdQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetByCustomerIdAsync(request.CustomerId);
            var cleaningPlanModel = _mapper.Map<List<CleaningPlanModel>>(cleaningPlanEntity);
            return cleaningPlanModel;
        }

        public async Task<CleaningPlanModel> Handle(CleaningPlanCreateRequest request,
            CancellationToken cancellationToken)
        {
            var cleaningPlan = new CleaningPlanEntity()
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

        public async Task<Unit> Handle(GenericDeleteRequest<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }

        public async Task<CleaningPlanModel> Handle(CleaningPlanUpdateRequest request,
            CancellationToken cancellationToken)
        {
            var cleaningPlan = new CleaningPlanEntity()
            {
                Title = request.Title,
                Description = request.Description
            };
            var cleaningPlanEntity = await _repository.UpdateAsync(cleaningPlan);
            var cleaningPlanModel = _mapper.Map<CleaningPlanModel>(cleaningPlanEntity);
            return cleaningPlanModel;
        }
    }
}
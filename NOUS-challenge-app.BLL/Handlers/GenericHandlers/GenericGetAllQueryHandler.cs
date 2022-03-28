using AutoMapper;
using MediatR;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOUS_challenge_app.BLL.Handlers.GenericHandlers
{
    public class GenericGetAllQueryHandler : IRequestHandler<GenericGetAllQuery<CleaningPlanModel>, IEnumerable<CleaningPlanModel>>
    {
        private readonly IGenericRepository<CleaningPlanEntity> _repository;
        private readonly IMapper _mapper;

        public GenericGetAllQueryHandler(IMapper mapper, IGenericRepository<CleaningPlanEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CleaningPlanModel>> Handle(GenericGetAllQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetAllAsync();
            var cleaningPlanModel = _mapper.Map<IEnumerable<CleaningPlanModel>>(cleaningPlanEntity);
            return cleaningPlanModel;
        }
    }
}

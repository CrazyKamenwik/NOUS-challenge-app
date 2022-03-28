using AutoMapper;
using MediatR;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NOUS_challenge_app.BLL.Handlers.GenericHandlers
{
    public class GenericGetByIdQueryHandler : IRequestHandler<GenericGetByIdQuery<CleaningPlanModel>, CleaningPlanModel>
    {
        private readonly IGenericRepository<CleaningPlanEntity> _repository;
        private readonly IMapper _mapper;

        public GenericGetByIdQueryHandler(IMapper mapper, IGenericRepository<CleaningPlanEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CleaningPlanModel> Handle(GenericGetByIdQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetByIdAsync(request.Id);
            var cleaningPlanModel = _mapper.Map<CleaningPlanModel>(cleaningPlanEntity);
            return cleaningPlanModel;
        }
    }
}

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
    public class GenericGetByCustomerIdQueryHandler : IRequestHandler<GenericGetByCustomerIdQuery<CleaningPlanModel>, IEnumerable<CleaningPlanModel>>
    {

        private readonly IGenericRepository<CleaningPlanEntity> _repository;
        private readonly IMapper _mapper;

        public GenericGetByCustomerIdQueryHandler(IGenericRepository<CleaningPlanEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CleaningPlanModel>> Handle(GenericGetByCustomerIdQuery<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            var cleaningPlanEntity = await _repository.GetByCustomerIdAsync(request.CustomerId);
            var cleaningPlanModel = _mapper.Map<IEnumerable<CleaningPlanModel>>(cleaningPlanEntity);
            return cleaningPlanModel;
        }

    }
}

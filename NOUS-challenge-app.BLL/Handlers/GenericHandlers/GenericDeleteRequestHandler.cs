using MediatR;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NOUS_challenge_app.BLL.Handlers.GenericHandlers
{
    public class GenericDeleteRequestHandler : IRequestHandler<GenericDeleteRequest<CleaningPlanModel>, Unit>
    {

        private readonly IGenericRepository<CleaningPlanEntity> _repository;

        public GenericDeleteRequestHandler(IGenericRepository<CleaningPlanEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(GenericDeleteRequest<CleaningPlanModel> request,
            CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}

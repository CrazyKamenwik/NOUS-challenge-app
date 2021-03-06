using MediatR;
using NOUS_challenge_app.BLL.Interfaces;

namespace NOUS_challenge_app.BLL.Requests.Generics
{
    public class GenericUpdateRequest<TModel> : IRequest<TModel> where TModel : IModel
    {
    }
}
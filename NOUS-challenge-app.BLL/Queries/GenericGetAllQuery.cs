using MediatR;
using NOUS_challenge_app.BLL.Interfaces;
using System.Collections.Generic;

namespace NOUS_challenge_app.BLL.Queries
{
    public class GenericGetAllQuery<TModel> : IRequest<IEnumerable<TModel>> where TModel : IModel
    {
    }
}
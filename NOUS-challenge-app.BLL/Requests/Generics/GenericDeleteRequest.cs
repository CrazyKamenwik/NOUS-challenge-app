using System;
using MediatR;
using NOUS_challenge_app.BLL.Interfaces;

namespace NOUS_challenge_app.BLL.Requests.Generics
{
    public class GenericDeleteRequest<TModel> : IRequest<Unit> where TModel : IModel
    {
        public Guid Id { get; set; }

        public GenericDeleteRequest(Guid id)
        {
            Id = id;
        }
    }
}

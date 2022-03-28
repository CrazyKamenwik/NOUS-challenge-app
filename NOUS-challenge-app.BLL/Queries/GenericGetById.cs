using MediatR;
using NOUS_challenge_app.BLL.Interfaces;
using System;

namespace NOUS_challenge_app.BLL.Queries
{
    public class GenericGetByIdQuery<TModel> : IRequest<TModel> where TModel : IModel
    {
        public Guid Id { get; set; }

        public GenericGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
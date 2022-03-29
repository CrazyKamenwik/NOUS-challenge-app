using MediatR;
using NOUS_challenge_app.BLL.Interfaces;
using System.Collections.Generic;

namespace NOUS_challenge_app.BLL.Queries
{
    public class GenericGetByCustomerIdQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : IModel
    {
        public int CustomerId { get; set; }

        public GenericGetByCustomerIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
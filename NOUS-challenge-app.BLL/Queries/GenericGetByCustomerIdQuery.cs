using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NOUS_challenge_app.BLL.Interfaces;

namespace NOUS_challenge_app.BLL.Queries
{
    public class GenericGetByCustomerIdQuery<TEntity> : IRequest<List<TEntity>> where TEntity : IModel
    {
        public int CustomerId { get; set; }

        public GenericGetByCustomerIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}

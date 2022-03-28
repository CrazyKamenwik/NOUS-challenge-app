using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NOUS_challenge_app.BLL.Interfaces;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.BLL.Requests.Generics;
using System;
using System.Threading.Tasks;

namespace NOUS_challenge_app.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GenericController<TModel> : Controller where TModel : class, IModel
    {

        private readonly IMediator _mediator;

        public GenericController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GenericGetAllQuery<TModel>();
            if (query == null)
            {
                throw new Exception("Unfortunately, there is no items." +
                                    " Try again later.");
            }
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var query = new GenericGetByIdQuery<TModel>(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                throw new Exception(
                    $"\nUnfortunately, something went wrong." +
                    $" There is no item with ({id}) ID.");
            }

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int id)
        {
            var query = new GenericGetByCustomerIdQuery<TModel>(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                throw new Exception(
                    $"\nUnfortunately, something went wrong." +
                    $" There is no item with ({id}) ID.");
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<Unit> DeleteAsync(Guid id)
        {
            var command = new GenericDeleteRequest<TModel>(id);
            if (command == null)
            {
                throw new Exception(
                    $"Unfortunately, something went wrong." +
                    $" There is no item with ({id}) ID.");
            }

            await _mediator.Send(command);
            return Unit.Value;
        }
    }
}

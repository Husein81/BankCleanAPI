using Microsoft.AspNetCore.Mvc;
using MediatR;
using Bank.Domain.Entities;
using Bank.Application.DTOs;
using Bank.Application.Commands;
using Bank.Application.Repositories;
using Bank.Application.Commands.CustomerCommands;
using Bank.Shared;
using Bank.Application.Queries.CustomerQueries;

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) 
            => _mediator = mediator;


        [HttpPost]
        public async Task<Response<CustomerDTO>> Post(CreateCustomerCommand command,CancellationToken cancellationToken)
            => await _mediator.Send(command,cancellationToken);
        [HttpPut]
        public async Task<Response<CustomerDTO>> Put(UpdateCustomerCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeleteCustomerCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpGet]
        public async Task<List<CustomerDTO>> Get([FromQuery] GetAllCustomersQuery query, CancellationToken cancellationToken)
             => await _mediator.Send(query, cancellationToken);

        [HttpGet("byId")]
        public async Task<CustomerDTO> Get([FromQuery] GetCustomerQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);


        
    }
}
 
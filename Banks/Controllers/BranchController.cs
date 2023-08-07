using Bank.Application.Commands.BranchCommands;
using Bank.Application.DTOs;
using Bank.Application.Queries;
using Bank.Application.Queries.BranchQueries;
using Bank.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
             => _mediator = mediator;
        [HttpPost]
        public async Task<Response<BranchDTO>> AddBranch(CreateBranchCommand command)
             => await _mediator.Send(command);
        

        [HttpPut]
        public async Task<Response<BranchDTO>> UpdateBranch(UpdateBranchCommand command)
            => await _mediator.Send(command);

        [HttpGet]
        public async Task<List<BranchDTO>> Get([FromQuery] GetAllBranchesQuery query,CancellationToken cancellationToken)
            => await _mediator.Send(query,cancellationToken);
        [HttpGet("ByID")]
        public async Task<BranchDTO> Get([FromQuery] GetBranchQuery query, CancellationToken cancellationToken)
             => await _mediator.Send(query, cancellationToken);
        [HttpDelete]

        public async Task DeleteBranch(DeleteBranchCommand command)
             => await _mediator.Send(command);


        public async Task DeleteBranch(DeleteBranchCommand command, CancellationToken cancellationToken)
           => await _mediator.Send(command, cancellationToken);

    }
}

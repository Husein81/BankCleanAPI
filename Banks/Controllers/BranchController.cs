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
        public async Task<BranchDTO> AddBranch(CreateBranchCommand command)
             => await _mediator.Send(command);

        [HttpPut]
        public async Task<BranchDTO> UpdateBranch(UpdateBranchCommand command)
            => await _mediator.Send(command);

        [HttpGet]
        public async Task<List<BranchDTO>> Get([FromQuery] GetAllBranchesQuery query,CancellationToken cancellationToken)
            => await _mediator.Send(query,cancellationToken);
        [HttpGet("ByID")]
        public async Task<BranchDTO> Get([FromQuery] GetBranchQuery query, CancellationToken cancellationToken)
             => await _mediator.Send(query, cancellationToken);
        [HttpDelete]
<<<<<<< HEAD
        public async Task DeleteBranch(DeleteBranchCommand command)
             => await _mediator.Send(command);
      
=======
        public async Task DeleteBranch(int id)
        {
            var branch=await _context.Branch.FirstOrDefaultAsync(x=>x.Id==id)
                ??throw new Exception("Not Found");
            _context.Remove(branch);
            await _context.SaveChangesAsync();
        }
>>>>>>> b15d96dd4e2bb03dbc53deb3e06e7715611a26c1
    }
}

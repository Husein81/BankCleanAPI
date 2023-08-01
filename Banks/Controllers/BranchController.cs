using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Bank.Domain;
using Bank.Application.Commands;

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
        public async Task<List<Customer>> GetBranchAsync()
        {
            return await _context.Customer.ToListAsync();
        }
        [HttpGet("GetBranchById")]
        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await _context.Branch.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpDelete]
        public async Task DeleteBranch(DeleteBranchCommand command)
             => await _mediator.Send(command);
      
    }
}

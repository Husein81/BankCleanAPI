using MediatR;
using Mapster;
using Bank.Domain;
using Bank.Application.Commands.BranchCommands;
using Bank.Application.DTOs;
using Bank.Application.Commands;
using Bank.Application.Repositories;
using Bank.Shared.Commands;
using Bank.Shared;

namespace Bank.Application.Commands.BranchCommands.Handlers
{
    public class CreateBranchHandler : ICommandHandler<CreateBranchCommand, BranchDTO>
    {
        private readonly IBranchRepository _branch;
        private readonly ICustomerRepository _customer;
        public CreateBranchHandler(IBranchRepository branch,ICustomerRepository customer)
        {
            _branch = branch;
            _customer = customer;
        }
        public async Task<Response<BranchDTO>> Handle(CreateBranchCommand request,CancellationToken cancellationToken)
        {
            var (id,Name, Address, Assets,customerId) = request;
            var customer = new List<Customer>();
            foreach(var customerid in customerId)
            {
                customer.Add(await _customer.GetByIdAsync(id,cancellationToken));
            }
            var branch = new Branch(Name, Address, Assets);
            var newBranch= await _branch.AddAsync(branch, cancellationToken);

            var setter = TypeAdapterConfig<Branch, BranchDTO>.NewConfig()
            .Map(dest => dest.id, src => src.Customers.Select(x => x.Id)).MaxDepth(2);
            return Response.Success(newBranch.Adapt<Branch, BranchDTO>(setter.Config), "Created Branch" + newBranch.Id);
        }
    }
}

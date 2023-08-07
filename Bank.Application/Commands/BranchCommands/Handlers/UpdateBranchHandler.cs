using Bank.Application.Commands.CustomerCommands;
using Bank.Application.DTOs;
using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Shared;
using Bank.Shared.Commands;
using Mapster;


namespace Bank.Application.Commands.BranchCommands.Handlers
{
    internal class UpdateBranchHandler : ICommandHandler<UpdateBranchCommand, BranchDTO>
    {
        private readonly ICustomerRepository _customer;
        private readonly IBranchRepository _branch;
        public UpdateBranchHandler(ICustomerRepository customer, IBranchRepository branch)
        {
            _customer = customer;
            _branch = branch;
        }
        public async Task<Response<BranchDTO>> Handle(UpdateBranchCommand request,CancellationToken cancellationToken)
        {
            var (id, name, address,assets,customerId) = request;

            var branch = await _branch.GetByIdAsync(id,cancellationToken);

            if (branch != null)
            {
                var newCustomer = new List<Customer>();

                foreach (var customerIds in customerId)
                {
                    newCustomer.Add(await _customer.GetByIdAsync(customerIds, cancellationToken));

                }
                branch.UpdateCustomer(newCustomer);
            }
                branch.Update(name, address,assets);

                var UpdatedBranch = await _branch.UpdateAsync(branch, cancellationToken);

                var setter = TypeAdapterConfig<Branch, BranchDTO>.NewConfig()
                 .Map(dest => dest.id, src => src.Customers.Select(x => x.Id)).MaxDepth(2);

                return Response.Success(UpdatedBranch.Adapt<Branch, BranchDTO>(setter.Config), "Branch Updated" + UpdatedBranch.Name);
            

        }
    }
}

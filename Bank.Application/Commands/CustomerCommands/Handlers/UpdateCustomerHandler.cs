using Bank.Application.DTOs;
using Bank.Application.Repositories;
using Bank.Shared;
using Bank.Shared.Commands;
using Bank.Domain;
using Mapster;

namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    internal class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand,CustomerDTO>
    {
        private readonly ICustomerRepository _customer;
        private readonly IBranchRepository _branch;
        public UpdateCustomerHandler(ICustomerRepository customer,IBranchRepository branch)
        {
            _customer = customer;
            _branch = branch;
        }
        public async Task<Response<CustomerDTO>> Handle(UpdateCustomerCommand request,CancellationToken cancellationToken)
        {
            var (id, name, address,branchId) = request;
            var customer=await _customer.GetByIdAsync(id,cancellationToken);
            if (branchId != null)
            {
                var newBranch = new List<Branch>();
                foreach (var branch in branchId)
                {
                    newBranch.Add(await _branch.GetByIdAsync(branch, cancellationToken));
                }
                customer.UpdateBranch(newBranch);                    
            }
                customer.UpdateDetails(name, address);

                var UpdatedCustomer= await _customer.UpdateAsync(customer,cancellationToken);

            var setter = TypeAdapterConfig<Branch, BranchDTO>.NewConfig()
                .Map(dest => dest.id, src => src.Customers.Select(x => x.Id)).MaxDepth(2);

            return Response.Success(UpdatedCustomer.Adapt<Customer, CustomerDTO>(setter.Config), "Cutomer Updated" + UpdatedCustomer.Name);
            

        }
    }
}

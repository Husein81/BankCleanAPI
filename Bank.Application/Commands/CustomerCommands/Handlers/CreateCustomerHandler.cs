using Bank.Application.Commands.CustomerCommands;
using Bank.Application.DTOs;
using Bank.Application.Repositories;
using Bank.Domain;
using Bank.Shared;
using Bank.Shared.Commands;
using Bank.Application.Commands;
using Bank.Application.DTOs;
using Bank.Application.Repositories;
using MediatR;
using Mapster;



namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    internal class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _customers;
        private readonly IBranchRepository _branches;

        public CreateCustomerHandler(ICustomerRepository customers, IBranchRepository branches)
        {
            _customers = customers;
            _branches = branches;
        }
        public async Task<Response<CustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var (id,name,address,branchId) = request;

            var branch = new List<Branch>();
            foreach (var br in branchId)
            {
                branch.Add(await _branches.GetByIdAsync(br,cancellationToken));
            }
            var customer = new Customer(name,address,branch);
            var newCustomer = await _customers.AddAsync(customer, cancellationToken);

            var setter = TypeAdapterConfig<Customer, CustomerDTO>.NewConfig()
                .Map(dest => dest.id, src => src.Branches.Select(i => i.Id)).MaxDepth(2);
            return Response.Success(newCustomer.Adapt<Customer, CustomerDTO>(setter.Config), "Created customer " + newCustomer.Id);
        }
    }
   
}

using Bank.Application.Commands;
using Bank.Application.DTOs;
using Bank.Application.Repositories;
using Bank.Domain;
using Bank.Shared;
using Bank.Shared.Commands;
using Mapster;

namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    internal class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _customers;
        private readonly IBranchRepository branches;

        public CreateCustomerHandler(ICustomerRepository customers, IBranchRepository branches)
        {
            _customers = customers;
            this.branches = branches;
        }
        public async Task<Response<CustomerDTO>> Handle(CreateCustomerCommand command) 
        {
            var (id,name, address) = command;
            var customer = await _customers.GetByIdAsync(id);
            var add=await CustomerRepository.AddAsync(customer);
            return add.Adapt<Customer, CustomerDTO>();
        }
    }
   
}

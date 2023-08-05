using MediatR;
using Bank.Application.Repositories;
using Bank.Shared.Commands;
using Bank.Shared;

namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customer;
        public DeleteCustomerHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public async Task<Response<Unit>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customer.GetByIdAsync(request.id,cancellationToken);
            if (customer.Branches is not null)
                foreach (var cust in customer.Branches)
                    customer.Branches.Remove(cust);
            await _customer.UpdateAsync(customer, cancellationToken);
            await _customer.DeleteAsync(request.id,cancellationToken);
            return Response.Success(Unit.Value, "Deleted Customer");
        }

    }
}

using Bank.Application.Repositories;
using Bank.Shared;
using MediatR;

namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    public class DeleteCustomerHandlerBase
    {
        private readonly ICustomerRepository _customer;
        public async Task<Response<Unit>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customer.GetByIdAsync(request.id, cancellationToken);
            if (customer.Branches != null)
                foreach (var cust in customer.Branches)
                    customer.Branches.Remove(cust);
            await _customer.UpdateAsync(customer, cancellationToken);
            await _customer.DeleteAsync(request.id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted Customer");
        }
    }
}
using MediatR;
using Bank.Application.Repositories;

namespace Bank.Application.Commands.CustomerCommands.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommad, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommadHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Unit> DeleteHandle(DeleteCustomerCommad request,CancellationToken cancellationToken)
        {
            await CustomerRepository.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}

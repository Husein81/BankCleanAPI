using Bank.Application.DTOs;
using Bank.Shared.Queries;
using Bank.Application.Queries;
using Bank.Application.Repositories;
using Mapster;
using Bank.Domain;
using Bank.Shared.Queries;

namespace Bank.Application.Queries.CustomerQueries.Handlers
{
    internal class GetCustomerHandler : IQueryHandler<GetAllCustomersQuery, CustomerDTO>
    {
        public readonly ICustomerRepository _customer;
        public GetCustomerHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public async Task<CustomerDTO> Handle(GetCustomerQuery query,CancellationToken cancellationToken)
        {
            var customer = await _customer.GetWholeByIdAsync(query.Id,cancellationToken );
            var setter = TypeAdapterConfig<Customer, CustomerDTO>.NewConfig()
                 .Map(dest => dest.id, src => src.Branches.Select(x => x.Id)).MaxDepth(2);
            return customer.Adapt<Customer, CustomerDTO>(setter.Config);
        }
    }
}

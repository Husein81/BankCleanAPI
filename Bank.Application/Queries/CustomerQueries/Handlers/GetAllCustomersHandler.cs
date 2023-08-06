using Bank.Application.DTOs;
using Bank.Shared.Queries;
using Bank.Application.Repositories;
using Bank.Domain;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting;
using Bank.Shared.Queries;
using Bank.Application.Queries.CustomerQueries;

namespace Bank.Application.Queries.Handlers
{
    internal class GetAllCustomersHandler : IQueryHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private readonly ICustomerRepository _customer;
        public GetAllCustomersHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customer.GetWholeAsync(cancellationToken);

            var setter = TypeAdapterConfig<Customer, CustomerDTO>.NewConfig()
                .Map(dest => dest.id, src => src.Branches.Select(t => t.Id))
                .MaxDepth(2);
            var customerDTO = customers.Adapt<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(setter.Config);

            return customerDTO.ToList();
        }
    }
    
}

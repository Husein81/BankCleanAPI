using Bank.Application.DTOs;
using Bank.Shared.Queries;

namespace Bank.Application.Queries.CustomerQueries
{
    public record GetCustomerQuery(int Id) : IQuery<CustomerDTO>;
}

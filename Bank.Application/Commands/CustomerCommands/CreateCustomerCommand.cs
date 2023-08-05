using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.CustomerCommands
{
    public record CreateCustomerCommand(int id,string Name, string Address,List<int>branchId) : IRequest<CustomerDTO>;
}

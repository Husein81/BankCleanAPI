using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;
namespace Bank.Application.Commands.CustomerCommands
{
    public record CreateCustomerCommand(int id,string Name, string Address,List<int>branchId) : ICommand<CustomerDTO>;
}

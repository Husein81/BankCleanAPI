using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;
namespace Bank.Application.Commands.CustomerCommands
{
   public record UpdateCustomerCommand(int id ,string name,string address,List<int>BranchId) : ICommand<CustomerDTO>;
}

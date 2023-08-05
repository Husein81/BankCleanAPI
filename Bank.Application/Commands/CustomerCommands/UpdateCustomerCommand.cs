using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.CustomerCommands
{
   public record UpdateCustomerCommand(int id ,string name,string address,List<int>BranchId) : IRequest<CustomerDTO>;
}

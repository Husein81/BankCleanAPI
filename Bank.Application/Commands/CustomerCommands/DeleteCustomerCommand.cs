using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.CustomerCommands
{
   public record DeleteCustomerCommand(int id) : IRequest<CustomerDTO>;
}

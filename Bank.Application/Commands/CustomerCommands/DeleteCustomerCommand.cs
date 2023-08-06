using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;
namespace Bank.Application.Commands.CustomerCommands
{
   public record DeleteCustomerCommand(int id) : ICommand<CustomerDTO>;
}

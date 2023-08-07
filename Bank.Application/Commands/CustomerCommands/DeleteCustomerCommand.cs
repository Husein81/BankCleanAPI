using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;
using Bank.Shared;

namespace Bank.Application.Commands.CustomerCommands
{
   public record DeleteCustomerCommand(int id) : ICommand<Unit>;
}


using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;

namespace Bank.Application.Commands.BranchCommands
{
    public record UpdateBranchCommand(int id, string name, string address,double assets,List<int> customerID) : ICommand<BranchDTO>;
}

using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;

namespace Bank.Application.Commands.BranchCommands
{
    public record CreateBranchCommand(int id, string Name, string Address,double Assets,List<int> customerId) : ICommand<BranchDTO>;
}


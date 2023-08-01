using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.BranchCommands
{
    public record CreateBranchCommand(int id, string Name, string Address,double Assets) : IRequest<BranchDTO>;
}


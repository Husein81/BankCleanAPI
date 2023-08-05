
using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.BranchCommands
{
    public record UpdateBranchCommand(int id, string name, string address,double assets,List<int> customerID) : IRequest<BranchDTO>;
}

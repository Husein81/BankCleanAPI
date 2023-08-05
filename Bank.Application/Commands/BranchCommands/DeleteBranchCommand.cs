using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.BranchCommands
{
    public record DeleteBranchCommand(int id) : IRequest<BranchDTO>;
}
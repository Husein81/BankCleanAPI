using MediatR;
using Bank.Application.DTOs;
using Bank.Shared.Commands;
namespace Bank.Application.Commands.BranchCommands
{
    public record DeleteBranchCommand(int id) : ICommand<BranchDTO>;
}
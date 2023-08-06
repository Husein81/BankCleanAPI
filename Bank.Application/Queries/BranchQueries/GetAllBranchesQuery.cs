using Bank.Application.DTOs;
using Bank.Shared.Queries;

namespace Bank.Application.Queries
{
   public record GetAllBranchesQuery : IQuery<List<BranchDTO>>;
}

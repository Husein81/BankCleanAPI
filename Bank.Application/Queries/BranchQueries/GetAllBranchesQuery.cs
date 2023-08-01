using Bank.Application

namespace Bank.Shared.Queries.BranchQueries
{
   public record GetAllBranchesQuery : IQuery<List<BranchDTO>>
}

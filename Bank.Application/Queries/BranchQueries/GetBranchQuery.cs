using Bank.Application.DTOs;
using Bank.Shared.Queries;

namespace Bank.Application.Queries.BranchQueries
{
  public record GetBranchQuery(int Id) : IQuery<BranchDTO>;
}

using Bank.Application.DTOs;
using Bank.Shared.Queries;
using Bank.Application.Queries;
using Bank.Application.Repositories;
using Mapster;
using Bank.Domain;

namespace Bank.Application.Queries.BranchQueries.Handlers
{
    internal class GetBranchHandler : IQueryHandler<GetBranchQuery ,BranchDTO>
    {
        public readonly IBranchRepository _branch;
        public GetBranchHandler(IBranchRepository branch)
        {
            _branch = branch;
        }
        public async Task<BranchDTO> Handle(GetBranchQuery query,CancellationToken cancellationToken)
        {
            var branch = await _branch.GetWholeByIdAsync(query.Id,cancellationToken);
            var setter = TypeAdapterConfig<Branch, BranchDTO>.NewConfig()
                 .Map(dest => dest.id, src => src.Customers.Select(x => x.Id)).MaxDepth(2);
            return branch.Adapt<Branch, BranchDTO>(setter.Config);
        }
    }
}

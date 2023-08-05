using Bank.Application.DTOs;
using Bank.Shared.Queries;
using Bank.Application.Repositories;
using Bank.Domain;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting;


namespace Bank.Application.Queries.Handlers
{
    internal class GetAllBranchesHandler : IQueryHandler<GetAllBranchesQuery,List<BranchDTO>>
    {
        private readonly IBranchRepository _branch;
        public GetAllBranchesHandler(IBranchRepository branch)
        {
            _branch = branch;
        }
        public async Task<List<BranchDTO>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branch.GetWholeAsync(cancellationToken);

            var setter = TypeAdapterConfig<Branch, BranchDTO>.NewConfig()
                .Map(dest => dest.id, src => src.Customers.Select(t => t.Id))
                .MaxDepth(2);
            var branchDTO = branches.Adapt<IEnumerable<Branch>, IEnumerable<BranchDTO>>(setter.Config);

            return branchDTO.ToList();
        }
    }
}

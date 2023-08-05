using Bank.Application.Repositories;
using Bank.Application.Commands;
using Bank.Shared;
using Bank.Shared.Commands;

using MediatR;


namespace Bank.Application.Commands.BranchCommands.Handlers
{
    public class DeleteBranchHandler : ICommandHandler<DeleteBranchCommand, Unit>
    {
        private readonly IBranchRepository _branch;
        public DeleteBranchHandler(IBranchRepository branch)
        {
            _branch = branch;
        }
        public async Task<Response<Unit>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branch.GetByIdAsync(request.id,cancellationToken);
            if (branch.Customers is not null)
                foreach (var cust in branch.Customers)
                    branch.Customers.Remove(cust);
            await _branch.UpdateAsync(branch,cancellationToken);
            await _branch.DeleteAsync(request.id,cancellationToken);
            return Response.Success(Unit.Value, "Deleted Branch");
        }
    }
}

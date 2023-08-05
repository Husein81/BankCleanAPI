using MediatR;
namespace Bank.Shared.Queries
{
    public interface IQueryHandler<TIn, TOut> : IRequestHandler<TIn, TOut>
        where TIn : IQuery<TOut>
    { }
}
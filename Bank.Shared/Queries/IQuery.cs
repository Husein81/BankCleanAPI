using MediatR;

namespace Bank.Shared.Queries
{
    public interface IQuery<TOut> : IRequest<TOut> { }
}
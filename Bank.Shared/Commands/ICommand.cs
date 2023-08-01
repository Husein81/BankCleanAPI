using MediatR;
namespace Bank.Shared.Commands
{
   public interface ICommand<T> : IRequest<Response<T>> { }
   
}

using MediatR;
using WideWorldImporters.Data.Models;

namespace WideWorldImporters.Data.Commands
{
    public abstract class WideWorldImportersHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected WideWorldImportersContext DbContext { get; }

        protected WideWorldImportersHandler(WideWorldImportersContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract TResponse Handle(TRequest message);
    }
}

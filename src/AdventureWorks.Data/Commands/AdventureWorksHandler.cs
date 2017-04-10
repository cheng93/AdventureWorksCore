using AdventureWorks.Data.Models;
using MediatR;

namespace AdventureWorks.Data.Commands
{
    public abstract class AdventureWorksHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected AdventureWorks2014Context DbContext { get; }

        protected AdventureWorksHandler(AdventureWorks2014Context dbContext)
        {
            DbContext = dbContext;
        }

        public abstract TResponse Handle(TRequest message);
    }
}

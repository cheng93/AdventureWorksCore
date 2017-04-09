using MediatR;

namespace AdventureWorks.Common.Commands
{
    public abstract class Request<TResponse> : IRequest<TResponse>
    {
        public RequestSettings Settings { get; set; } = RequestSettings.Default;
    }
}

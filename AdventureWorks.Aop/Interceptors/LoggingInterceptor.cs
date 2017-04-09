using Castle.DynamicProxy;
using Serilog;
using SerilogTimings.Extensions;

namespace AdventureWorks.Aop.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        private const string _template = "Executing {handler}.{method}";

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var op =_logger.BeginOperation(_template, invocation.TargetType.Name, invocation.Method.Name))
            {
                invocation.Proceed();
                op.Complete();
            }
        }
    }
}

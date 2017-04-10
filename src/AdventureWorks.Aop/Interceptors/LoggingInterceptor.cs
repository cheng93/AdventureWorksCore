using Castle.DynamicProxy;
using Serilog;
using SerilogTimings.Extensions;
using System;

namespace AdventureWorks.Aop.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        private const string _template = "Executing {handler}.{method}";

        private const string _exceptionTemplate = "{Exeception} was thrown for {handler}.{method}";

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var op = _logger.BeginOperation(_template, invocation.TargetType.Name, invocation.Method.Name))
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, _exceptionTemplate, ex.GetType().Name, invocation.TargetType.Name, invocation.Method.Name);
                    throw;
                }
                op.Complete();
            }
        }
    }
}

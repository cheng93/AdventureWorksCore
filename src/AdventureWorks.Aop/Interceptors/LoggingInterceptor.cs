using Castle.DynamicProxy;
using Serilog;
using SerilogTimings.Extensions;
using System;

namespace AdventureWorks.Aop.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        private const string _template = "Executing {method}";

        private const string _exceptionTemplate = "{Exeception} was thrown for {method}";

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = $"{invocation.TargetType.FullName}.{invocation.Method.Name}";
            using (var op = _logger.BeginOperation(_template, new object[] { method }))
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, _exceptionTemplate, ex.GetType().Name, method);
                    throw;
                }
                op.Complete();
            }
        }
    }
}

﻿using AdventureWorks.Aop.Interceptors;
using Castle.DynamicProxy;
using Moq;
using Serilog;
using Serilog.Events;
using System;
using System.Reflection;
using Xunit;

namespace AdventureWorks.Aop.Tests.Interceptors.LoggingInterceptorTests
{
    public class LoggingInterceptorTest
    {
        private class MethodInfoHack
        {
            public void Method() { }
        }

        public LoggingInterceptorTest()
        {
            LoggerMock
                .Setup(x => x.Write(It.IsAny<LogEventLevel>(), It.IsAny<string>(), It.IsAny<object[]>()))
                .Verifiable();

            var typeMock = new Mock<Type>();
            typeMock
                .Setup(x => x.FullName)
                .Returns(FullName);

            InvocationMock
                .Setup(x => x.TargetType)
                .Returns(typeMock.Object);

            var methodInfo = typeof(MethodInfoHack).GetMethod(MethodName);

            InvocationMock
                .Setup(x => x.Method)
                .Returns(methodInfo);

            Subject = new LoggingInterceptor(LoggerMock.Object);
        }

        protected LoggingInterceptor Subject { get; set; }

        protected Mock<ILogger> LoggerMock { get; set; } = new Mock<ILogger>();
        protected Mock<IInvocation> InvocationMock { get; set; } = new Mock<IInvocation>();

        protected string FullName => "Namespace.Type";
        protected string MethodName => "Method";
        protected string FullMethodName => $"{FullName}.{MethodName}";
        protected string Template => "Executing {method}";
    }

    public class LoggingInterceptorTests_InvocationSuccess : LoggingInterceptorTest
    {
        [Fact]
        public void LoggerShouldLog()
        {
            Subject.Intercept(InvocationMock.Object);

            LoggerMock.Verify(x => x.Write(
                LogEventLevel.Information,
                It.Is<string>(y => y.StartsWith(Template)),
                new object[] {
                    FullMethodName,
                    It.IsAny<string>(),
                    It.IsAny<double>()
                }));
        }
    }

    public class LoggingInterceptorTests_InvocationThrows : LoggingInterceptorTest
    {
        public LoggingInterceptorTests_InvocationThrows()
        {
            LoggerMock
                .Setup(x => x.Error(It.IsAny<Exception>(), It.IsAny<string>(), It.IsAny<object[]>()))
                .Verifiable();

            InvocationMock
                .Setup(x => x.Proceed())
                .Throws<ArgumentException>();
        }

        protected string ExceptionTemplate => "{Exeception} was thrown for {method}";
        protected string ExceptionName => "ArgumentException";

        [Fact]
        public void LoggerShouldLog()
        {
            Assert.Throws<ArgumentException>(() => Subject.Intercept(InvocationMock.Object));

            LoggerMock.Verify(x => x.Write(
                LogEventLevel.Warning,
                It.Is<string>(y => y.StartsWith(Template)),
                new object[] {
                    FullMethodName,
                    It.IsAny<string>(),
                    It.IsAny<double>()
                }));
        }

        [Fact]
        public void LoggerShouldLogException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Subject.Intercept(InvocationMock.Object));

            LoggerMock.Verify(x => x.Error(
                exception,
                ExceptionTemplate,
                ExceptionName,
                FullMethodName));
        }
    }
}

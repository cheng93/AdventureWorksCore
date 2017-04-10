using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace AdventureWorks.Aop.Hooks
{
    public class RequestHandlerGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return methodInfo.Name == "Handle";
        }
    }
}

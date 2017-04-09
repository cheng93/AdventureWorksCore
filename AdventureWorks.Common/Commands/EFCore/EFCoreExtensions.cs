using System.Linq;

namespace AdventureWorks.Common.Commands.EFCore
{
    public static class EFCoreExtensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> query, RequestSettings settings)
        {
            return query.Skip(settings.Skip).Take(settings.Take);
        }
    }
}

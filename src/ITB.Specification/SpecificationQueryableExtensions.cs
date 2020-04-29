using System.Linq;

namespace ITB.Specification
{
    public static class SpecificationQueryableExtensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, Specification<T> specification)
        {
            return query.Where(specification.Predicate);
        }
    }
}

using System;
using System.Linq.Expressions;

namespace ITB.Specification
{
    public static class SpecificationExtension
    {
        public static Specification<T> AsSpecification<T>(this Expression<Func<T, bool>> expr)
            => new ExpressionSpecification<T>(expr);
    }
}

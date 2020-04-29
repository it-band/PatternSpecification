using System;
using System.Linq;
using System.Linq.Expressions;

namespace ITB.Specification
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;

        public override Expression<Func<T, bool>> Predicate => Not(_left.Predicate);

        public NotSpecification(Specification<T> left)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
        }

        private static Expression<Func<T, bool>> Not(Expression<Func<T, bool>> left)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            var notExpression = Expression.Not(left.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(notExpression, left.Parameters.Single());
            return lambda;
        }
    }
}

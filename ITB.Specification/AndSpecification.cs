using System;
using System.Linq;
using System.Linq.Expressions;

namespace ITB.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public override Expression<Func<T, bool>> Predicate
        {
            get
            {
                var firstSpecification = Specifications.First();

                if (Specifications.Length == 1)
                {
                    return firstSpecification.Predicate;
                }

                return Specifications.Skip(1).Aggregate(firstSpecification.Predicate,
                    (current, specification) => And(current, specification.Predicate));
            }
        }

        public AndSpecification(params Specification<T>[] specifications) : base(specifications)
        {
        }

        private Expression<Func<T, bool>> And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var visitor = new SwapVisitor(left.Parameters[0], right.Parameters[0]);
            var binaryExpression = Expression.AndAlso(visitor.Visit(left.Body), right.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, right.Parameters);
            return lambda;
        }
    }
}

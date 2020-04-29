namespace ITB.Specification
{
    public class SpecificationFactory : ISpecificationFactory
    {
        public Specification<T> Create<T>()
        {
            return new DefaultSpecification<T>();
        }
    }
}

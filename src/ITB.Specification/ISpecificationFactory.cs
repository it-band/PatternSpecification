namespace ITB.Specification
{
    public interface ISpecificationFactory
    {
        Specification<T> Create<T>();
    }
}

using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddSingleton(ImplementationOf = typeof(ISingletonService))]
    public sealed class SingletonService : ISingletonService
    {
        public Guid Id { get; }

        public SingletonService()
        {
            Id = Guid.NewGuid();
        }
    }


}

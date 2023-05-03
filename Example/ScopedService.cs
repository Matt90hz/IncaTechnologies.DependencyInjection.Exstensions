using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddScoped(ImplementationOf = typeof(IScopedService))]
    public sealed class ScopedService : IScopedService
    {
        public Guid Id { get; }

        public ScopedService()
        {
            Id = Guid.NewGuid();
        }
    }


}

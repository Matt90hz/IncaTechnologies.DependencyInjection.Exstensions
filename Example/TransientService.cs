using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddTransient(ImplementationOf = typeof(ITransientService))]
    public sealed class TransientService : ITransientService
    {
        public Guid Id { get; }

        public TransientService()
        {
            Id = Guid.NewGuid();
        }
    }


}

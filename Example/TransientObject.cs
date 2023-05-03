using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddTransient]
    public sealed class TransientObject 
    {
        public Guid Id { get; }

        public TransientObject()
        {
            Id = Guid.NewGuid();
        }
    }

}

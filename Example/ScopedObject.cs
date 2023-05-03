using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddScoped]
    public sealed class ScopedObject 
    {
        public Guid Id { get; }

        public ScopedObject()
        {
            Id = Guid.NewGuid();
        }
    }


}

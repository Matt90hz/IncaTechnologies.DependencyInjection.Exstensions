using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddSingleton]
    public sealed class SingletonObject 
    {
        public Guid Id { get; }

        public SingletonObject()
        {
            Id = Guid.NewGuid();
        }
    }


}

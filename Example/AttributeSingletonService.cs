namespace Example
{
    public sealed class AttributeSingletonService : IAttributeSingletonService
    {
        public Guid Id { get; }

        public AttributeSingletonService()
        {
            Id = Guid.NewGuid();
        }
    }
}

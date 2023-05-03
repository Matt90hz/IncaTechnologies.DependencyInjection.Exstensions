namespace Example
{
    public sealed class AttributeScopedService : IAttributeScopedService
    {
        public Guid Id { get; }

        public AttributeScopedService()
        {
            Id = Guid.NewGuid();
        }
    }
}

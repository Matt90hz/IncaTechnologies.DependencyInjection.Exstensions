namespace Example
{
    public sealed class AttributeTransientService : IAttributeTransientService
    {
        public Guid Id { get; }

        public AttributeTransientService()
        {
            Id = Guid.NewGuid();
        }
    }
}

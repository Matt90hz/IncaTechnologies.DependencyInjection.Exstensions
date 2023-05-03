using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddTransientService(typeof(AttributeTransientService))]
    public interface IAttributeTransientService
    {
        Guid Id { get; }
    }
}

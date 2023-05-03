using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddScopedService(typeof(AttributeScopedService))]
    public interface IAttributeScopedService
    {
        Guid Id { get; }
    }
}

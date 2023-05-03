using IncaTechnologies.DependencyInjection.Exstensions.Attributes;

namespace Example
{
    [AddScopedService(typeof(ScopedService))]
    public interface IScopedService
    {
        Guid Id { get; }
    }


}

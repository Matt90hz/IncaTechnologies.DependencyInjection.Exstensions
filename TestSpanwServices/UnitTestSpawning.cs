using FluentAssertions;
using IncaTechnologies.DependencyInjection.Exstensions.Attributes;
using Microsoft.Extensions.DependencyInjection;
using IncaTechnologies.DependencyInjection.Exstensions;

namespace TestSpanwServices;

[Spawn]
class SpawnableService 
{
    readonly ServiceEventSource _serviceEventSource;

    public SpawnableService(ServiceEventSource serviceEventSource)
    {
        _serviceEventSource = serviceEventSource;
        _serviceEventSource.ServiceEvent += ServiceEventSource_ServiceEvent;
    }

    void ServiceEventSource_ServiceEvent(object? sender, EventArgs e)
    {
        _serviceEventSource.IsBeenSpawned = true;
    }
}

class ServiceEventSource
{
    public bool IsBeenSpawned { get; set; }

    public event EventHandler? ServiceEvent;

    public void TriggerServiceEvent()
    {
        ServiceEvent?.Invoke(this, EventArgs.Empty);
    }
}

public class UnitTestSpawning
{
    [Fact]
    public void NotSpawnService_IsBeenSpawn_IsFalse()
    {
        //Arrange
        var serviceCollection = new ServiceCollection()
            .AddSingleton<ServiceEventSource>()
            .AddSingleton<SpawnableService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        //Act
        var serviceEventSource = serviceProvider.GetRequiredService<ServiceEventSource>();
        serviceEventSource.TriggerServiceEvent();

        //Assert
        serviceEventSource.IsBeenSpawned.Should().BeFalse();
    }

    [Fact]
    public void SpawnService_IsBeenSpawn_IsTrue()
    {
        //Arrange
        var serviceCollection = new ServiceCollection()
            .AddSingleton<ServiceEventSource>()
            .AddSingleton<SpawnableService>();

        var serviceProvider = serviceCollection
            .BuildServiceProvider()
            .SpawnServices();

        //Act
        var serviceEventSource = serviceProvider.GetRequiredService<ServiceEventSource>();
        serviceEventSource.TriggerServiceEvent();

        //Assert
        serviceEventSource.IsBeenSpawned.Should().BeTrue();
    }
}
# IncaTechnologies.DependencyInjection.Extensions

This library contains a series of utilities to deal with dependency injection.

## Register dependencies with attributes

Instead of having the dependency registered in a static class or multiple static classes, this feature gives you the opportunity to register all the dependencies by decorating classes or interfaces with attributes.

### Example

First, call the extension method `RegisterFromAttributes(this IServiceCollection services, Assembly assembly)`. This is the only line of code you need in your service configuration. Of course multiple assembly can be registered.

``` CSharp
IHost host = Host
    .CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.RegisterFormAttributes(typeof(Program).Assembly);
    })
    .Build();
```

Decorate the classes of your project with the appropriate attribute.

``` CSharp
public interface IService
{
    ...
}

[AddSingleton(ImplementationOf = typeof(ISingletonService))]
public class Service
{
    ...
}
```

And that's it! Now your service will be resolved automatically with a sigleton scope from the dependency injection provider (Microsoft.Extensions.DependencyInjection).

It is also possible to register services from the service side rather than the implementation side.

``` CSharp
[AddSingletonService(typeof(Service))]
public interface IService
{
    ...
}

public class Service
{
    ...
}
```

And finally, its s possible to register concrete type directly.

``` CSharp
[AddSingleton]
public class SingletonObject 
{
    ...
}
```

## Spawn services using attributes
Sometimes while using dependency injection happens that a class is registered as a service but it never gets instantiated. This because the class might never get requested as a service.

### Scenario
In our application we have separate services to manage notification and navigation.
```csharp
//Navigate between pages in UI
public class Navigator
{
    public event EventHandler? BeforeNavigation;
    public event EventHandler? AfterNavigation;

    public void Navigate(Path to) 
    {
        BeforeNavigation?.Invoke(this, EventArgs.Empty);
        
        //navigation logic

        AfterNavigation?.Invoke(this, EventArgs.Empty);
    }
}

//Notify something to user in UI
public class Notificator
{
    public void NotifyLoaging() { ... }

    public void NotifyLoaded() { ... }
}
```
Let us assume that these two classes are registered as singleton services and now you want to notify to user that the tha page is loading. One way you might achieve this is by injecting the `Notificator` inside the `Navigator` and put the logic inside the `Navigate()` method. A cleaner solution might be having a class that orchestrate this behavior.
```csharp
public class LoadNotificationBehavior
{
    readonly Navigator _navigator;
    readonly Notificator _notificator;

    public NavigatorEventsHandler(Navigator navigator, Notificator notificator)
    {
        _navigator = navigator;
        _notificator = notificator;

        _navigator.BeforeNavigation += Navigator_BeforeNavigation;
        _navigator.AfterNavigation += Navigator_AfterNavigation;
    }

    void Navigator_BeforeNavigation(object sender, EventArgs args)
    {
        _notificator.NotifyLoading();
    }

    void Navigator_AfterNavigation(object sender, EventArgs args)
    {
        _notificator.NotifyLoaded();
    }
}
```
Now is uncommon that `LoadNotificationBehavior` will be injected anywhere therefore it will never be instantiated and so the loding notification will never be displayed.

### Solution
By using `SpawnAttribute` is possible to automatically instantiate or spawn these services so that they will work as intended.
- First mark the class to be spawned
```csharp
[Spawn]
public class LoadNotificationBehavior
{
    ...
}
```
- Then spawn the services using the `SpawnServices` method.
```csharp
//Inside you app configuration
var serviceProvider = serviceCollection
            .BuildServiceProvider()
            .SpawnServices();
```
- All the services marked with spawn will be instantiated

## Contribution

Do you like this project and you want to contribute report a bug or suggest a feature? You can do it via [GitHub](https://github.com/Matt90hz/IncaTechnologies.DependencyInjection.Exstensions).

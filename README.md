# Incatechnologies.DependencyInjection.Exstensions

This library contains a series of utilities to deal with dependency injection.

## Register dependencies with attributes

Instead of having the dependency registerd in a static class or multiple static classes. This feature give you the opportunity to register all the dependency by decorating classes or interfaces with attributes.

### Example

First call the exstension method `RegisterFromAttributes(this IServiceCollection services, Assembly assembly)` this is the only line of code you need in your service configuration. Of course multiple assembly can be registered.

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

And thats it, now your service will be resolved automatically with a sigleton scope from the dependency injection provider (Microsoft.Exstensions.DependencyInjection).

It is also possible register services from the service side rather than the implementation side.

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

And finally is possible to register concrete type direcly.

``` CSharp
[AddSingleton]
public class SingletonObject 
{
    ...
}
```

## Contribution

You like this project and you want to contribute, report a bug or suggest a feature. You can do it via [GitHub](https://github.com/Matt90hz/IncaTechnologies.DependencyInjection.Exstensions).
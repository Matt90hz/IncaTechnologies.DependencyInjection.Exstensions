# IncaTechnologies.DependencyInjection.Extensions

This library contains a series of utilities to deal with dependency injection.

## Register dependencies with attributes

Instead of having the dependency registerd in a static class or multiple static classes, this feature gives you the opportunity to register all the dependencies by decorating classes or interfaces with attributes.

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

And finally it s possible to register concrete type directly.

``` CSharp
[AddSingleton]
public class SingletonObject 
{
    ...
}
```

## Contribution

Do you like this project and you want to contribute report a bug or suggest a feature? You can do it via [GitHub](https://github.com/Matt90hz/IncaTechnologies.DependencyInjection.Exstensions).
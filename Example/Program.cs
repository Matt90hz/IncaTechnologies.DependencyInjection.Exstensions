using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IncaTechnologies.DependencyInjection.Exstensions;
using Example;
using Microsoft.Extensions.Logging;

//Configure an host to test if everything get registered correctily
IHost host = Host
    .CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.RegisterFormAttributes(typeof(Program).Assembly);
        services.AddTransient<Test>();
    })
    .Build();

//Run the test
var test = host.Services.GetRequiredService<Test>();
test.Run();

/// <summary>
/// Rough testing class just to make sure that everythig in working as intended.<br/>
/// Might be replaced by a test project in the future.
/// </summary>
internal sealed class Test
{  
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<Test> _logger;

    private IServiceProvider ServiceProvider { get; set; }

    private ISingletonService SingletonService => ServiceProvider.GetRequiredService<ISingletonService>();

    private IScopedService ScopedService => ServiceProvider.GetRequiredService<IScopedService>();

    private ITransientService TransientService => ServiceProvider.GetRequiredService<ITransientService>();

    private IAttributeSingletonService AttributeSingletonService => ServiceProvider.GetRequiredService<IAttributeSingletonService>();

    private IAttributeScopedService AttributeScopedService => ServiceProvider.GetRequiredService<IAttributeScopedService>();

    private IAttributeTransientService AttributeTransientService => ServiceProvider.GetRequiredService<IAttributeTransientService>();

    private SingletonObject SingletonObject => ServiceProvider.GetRequiredService<SingletonObject>();

    private ScopedObject ScopedObject => ServiceProvider.GetRequiredService<ScopedObject>();

    private TransientObject TransientObject => ServiceProvider.GetRequiredService<TransientObject>();

    public Test(IServiceScopeFactory serviceScopeFactory, ILogger<Test> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;

        ServiceProvider = _serviceScopeFactory.CreateScope().ServiceProvider;
    }

    public void Run()
    {
        //TEST SERVICES REGISTERD DECORATING THE CONCRETE IMPLEMENTATION

        //Retrive ids for the first time
        var singletonId_1 = SingletonService.Id;
        var scopedId_1 = ScopedService.Id;
        var transientId_1 = TransientService.Id;

        //Retrive ids again, only the trasient one should change
        var singletonId_2 = SingletonService.Id;
        var scopedId_2 = ScopedService.Id;
        var transientId_2 = TransientService.Id;

        //Create a new scope
        ServiceProvider = _serviceScopeFactory.CreateScope().ServiceProvider;

        //Retrive ids again, only the signleton ona shuld be the same
        var singletonId_3 = SingletonService.Id;
        var scopedId_3 = ScopedService.Id;
        var transientId_3 = TransientService.Id;

        //ASSERTIONS

        //all the ids of singleton service must be the same
        if(singletonId_1 == singletonId_2 && singletonId_2 == singletonId_3)
        {
            _logger.LogInformation("Singleton Service registered form the implementation is working correctly.");
        }
        else
        {
            _logger.LogError("Singleton Service registered form the implementation is not working correctly.\n{id1}\n{id2}\n{id3}", singletonId_1, singletonId_2, singletonId_3);
        }

        //only the ids part of the same scope should be the same
        if(scopedId_1 == scopedId_2 && scopedId_2 != scopedId_3 && scopedId_1 != scopedId_3)
        {
            _logger.LogInformation("Scoped Service registered form the implementation is working correctly.");
        }
        else
        {
            _logger.LogError("Scoped Service registered form the implementation is not working correctly.\n{id1}\n{id2}\n{id3}", scopedId_1, scopedId_2, scopedId_3);
        }

        //all the ids should be different
        if (transientId_1 != transientId_2 && transientId_2 != transientId_3 && transientId_1 != transientId_3)
        {
            _logger.LogInformation("Transient Service registered form the implementation is working correctly.");
        }
        else
        {
            _logger.LogError("Transient Service registered form the implementation is not working correctly.\n{id1}\n{id2}\n{id3}", transientId_1, transientId_2, transientId_3);
        }

        //TEST SERVICES REGISTERD DECORATING THE SERVICE INTERFACES

        //Retrive ids for the first time
        singletonId_1 = AttributeSingletonService.Id;
        scopedId_1 = AttributeScopedService.Id;
        transientId_1 = AttributeTransientService.Id;

        //Retrive ids again, only the trasient one should change
        singletonId_2 = AttributeSingletonService.Id;
        scopedId_2 = AttributeScopedService.Id;
        transientId_2 = AttributeTransientService.Id;

        //Create a new scope
        ServiceProvider = _serviceScopeFactory.CreateScope().ServiceProvider;

        //Retrive ids again, only the signleton ona shuld be the same
        singletonId_3 = AttributeSingletonService.Id;
        scopedId_3 = AttributeScopedService.Id;
        transientId_3 = AttributeTransientService.Id;

        //ASSERTIONS

        //all the ids of singleton service must be the same
        if (singletonId_1 == singletonId_2 && singletonId_2 == singletonId_3)
        {
            _logger.LogInformation("Singleton Service registered form the interface is working correctly.");
        }
        else
        {
            _logger.LogError("Singleton Service registered form the interface is not working correctly.\n{id1}\n{id2}\n{id3}", singletonId_1, singletonId_2, singletonId_3);
        }

        //only the ids part of the same scope should be the same
        if (scopedId_1 == scopedId_2 && scopedId_2 != scopedId_3 && scopedId_1 != scopedId_3)
        {
            _logger.LogInformation("Scoped Service registered form the interface is working correctly.");
        }
        else
        {
            _logger.LogError("Scoped Service registered form the interface is not working correctly.\n{id1}\n{id2}\n{id3}", scopedId_1, scopedId_2, scopedId_3);
        }

        //all the ids should be different
        if (transientId_1 != transientId_2 && transientId_2 != transientId_3 && transientId_1 != transientId_3)
        {
            _logger.LogInformation("Transient Service registered form the interface is working correctly.");
        }
        else
        {
            _logger.LogError("Transient Service registered form the interface is not working correctly.\n{id1}\n{id2}\n{id3}", transientId_1, transientId_2, transientId_3);
        }

        //TEST OBJECTS

        //Retrive ids for the first time
        singletonId_1 = SingletonObject.Id;
        scopedId_1 = ScopedObject.Id;
        transientId_1 = TransientObject.Id;

        //Retrive ids again, only the trasient one should change
        singletonId_2 = SingletonObject.Id;
        scopedId_2 = ScopedObject.Id;
        transientId_2 = TransientObject.Id;

        //Create a new scope
        ServiceProvider = _serviceScopeFactory.CreateScope().ServiceProvider;

        //Retrive ids again, only the signleton ona shuld be the same
        singletonId_3 = SingletonObject.Id;
        scopedId_3 = ScopedObject.Id;
        transientId_3 = TransientObject.Id;

        //ASSERTIONS

        //all the ids of singleton service must be the same
        if (singletonId_1 == singletonId_2 && singletonId_2 == singletonId_3)
        {
            _logger.LogInformation("Singleton Object is working correctly.");
        }
        else
        {
            _logger.LogError("Singleton Object is not working correctly.\n{id1}\n{id2}\n{id3}", singletonId_1, singletonId_2, singletonId_3);
        }

        //only the ids part of the same scope should be the same
        if (scopedId_1 == scopedId_2 && scopedId_2 != scopedId_3 && scopedId_1 != scopedId_3)
        {
            _logger.LogInformation("Scoped Object is working correctly.");
        }
        else
        {
            _logger.LogError("Scoped Object is not working correctly.\n{id1}\n{id2}\n{id3}", scopedId_1, scopedId_2, scopedId_3);
        }

        //all the ids should be different
        if (transientId_1 != transientId_2 && transientId_2 != transientId_3 && transientId_1 != transientId_3)
        {
            _logger.LogInformation("Transient Object is working correctly.");
        }
        else
        {
            _logger.LogError("Transient Object is not working correctly.\n{id1}\n{id2}\n{id3}", transientId_1, transientId_2, transientId_3);
        }

    }

}
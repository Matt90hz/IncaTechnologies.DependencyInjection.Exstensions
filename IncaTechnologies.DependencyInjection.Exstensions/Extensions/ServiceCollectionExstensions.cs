using IncaTechnologies.DependencyInjection.Exstensions.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IncaTechnologies.DependencyInjection.Exstensions
{
    /// <summary>
    /// Exstension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExstensions
    {
        /// <summary>
        /// Registers all the types inside the given <paramref name="assembly"/> that are decorated with any of the custom attribute in <see cref="Attributes"/>.
        /// </summary>
        /// <param name="services">Service collection in witch the services will be registered.</param>
        /// <param name="assembly">The assembly that contains the types to be registered</param>
        /// <returns><see cref="IServiceCollection"/> to chain the configuration.</returns>
        public static IServiceCollection RegisterFormAttributes(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types) 
            {              
                services.RegisterFromAttribute(type); 
            }

            return services;
        }

        /// <summary>
        /// Register a type if is decorated with a vaid attribute.
        /// </summary>
        /// <param name="services">Service collection in wich the services will be registered.</param>
        /// <param name="type">The type to analyze.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection RegisterFromAttribute(this IServiceCollection services, Type type)
        {
            return type.GetContextCustomAttribute() switch
            {
                AddSingletonAttribute attribute         => attribute.ImplementationOf is null ? services.AddSingleton(type) : services.AddSingleton(attribute.ImplementationOf, type),
                AddScopedAttribute attribute            => attribute.ImplementationOf is null ? services.AddScoped(type) : services.AddScoped(attribute.ImplementationOf, type),
                AddTransientAttribute attribute         => attribute.ImplementationOf is null ? services.AddTransient(type) : services.AddTransient(attribute.ImplementationOf, type),
                AddSingletonServiceAttribute attribute  => services.AddSingleton(type, attribute.Implementation),
                AddScopedServiceAttribute attribute     => services.AddScoped(type, attribute.Implementation),
                AddTransientServiceAttribute attribute  => services.AddTransient(type, attribute.Implementation),
                _ => services
            };
        }

        /// <summary>
        /// Returns the attribute form <see cref="Attributes"/> that decorates the type, if there is one.
        /// </summary>
        /// <param name="type">Type to analyse.</param>
        /// <returns>The attribute found or <c>null</c>.</returns>
        private static Attribute? GetContextCustomAttribute(this Type type)
        {
            //Crazy for some reason (i guess that GetCustomAttribute do not support nullable context) i cannot use ?? operator
            if (type.GetCustomAttribute<AddSingletonAttribute>() is AddSingletonAttribute addSingletonAttribute) return addSingletonAttribute;
            if (type.GetCustomAttribute<AddScopedAttribute>() is AddScopedAttribute addScopedAttribute) return addScopedAttribute;
            if (type.GetCustomAttribute<AddTransientAttribute>() is AddTransientAttribute addTransientAttribute) return addTransientAttribute;
            if (type.GetCustomAttribute<AddSingletonServiceAttribute>() is AddSingletonServiceAttribute addSingletonServiceAttribute) return addSingletonServiceAttribute;
            if (type.GetCustomAttribute<AddScopedServiceAttribute>() is AddScopedServiceAttribute addScopedServiceAttribute) return addScopedServiceAttribute;
            if (type.GetCustomAttribute<AddTransientServiceAttribute>() is AddTransientServiceAttribute addTransientServiceAttribute) return addTransientServiceAttribute;

            return null;
        }
        
    }
}

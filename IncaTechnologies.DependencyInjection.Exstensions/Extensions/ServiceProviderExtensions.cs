using IncaTechnologies.DependencyInjection.Exstensions.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace IncaTechnologies.DependencyInjection.Exstensions
{
    /// <summary>
    /// Provides utility functions for <see cref="IServiceProvider"/>.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// It looks for class marked with 
        /// </summary>
        /// <param name="serviceProvider">The provider used to spawn the services</param>
        /// <param name="assembly">The assembly to look in for class marked with <see cref="Attributes.SpawnAttribute"/>.</param>
        /// <returns></returns>
        public static IServiceProvider SpawnServices(this IServiceProvider serviceProvider, Assembly? assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();

            var markedTypes = assembly.DefinedTypes
                .Where(type => type.GetCustomAttributes<SpawnAttribute>().Any());

            foreach (var markedType in markedTypes)
            {
                serviceProvider.GetRequiredService(markedType);
            }

            return serviceProvider;
        }
    }
}

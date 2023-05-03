using Microsoft.Extensions.DependencyInjection;
using System;

namespace IncaTechnologies.DependencyInjection.Exstensions.Attributes
{
    /// <summary>
    /// Mark a class to ba added to a <see cref="IServiceCollection"/> as transient.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AddTransientAttribute : Attribute
    {
        /// <summary>
        /// The type of the service that the decorated class implements.<br/>
        /// If not provided the concrete class will be registered. 
        /// </summary>
        public Type? ImplementationOf { get; set; }
    }

}

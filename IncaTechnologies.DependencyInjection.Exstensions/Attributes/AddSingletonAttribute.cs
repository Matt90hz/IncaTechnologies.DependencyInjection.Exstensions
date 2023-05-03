using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncaTechnologies.DependencyInjection.Exstensions.Attributes
{
    /// <summary>
    /// Mark a class to ba added to a <see cref="IServiceCollection"/> as singleton.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AddSingletonAttribute : Attribute
    {
        /// <summary>
        /// The type of the service that the decorated class implements.<br/>
        /// If not provided the concrete class will be registered. 
        /// </summary>
        public Type? ImplementationOf { get; set; }
    }

}

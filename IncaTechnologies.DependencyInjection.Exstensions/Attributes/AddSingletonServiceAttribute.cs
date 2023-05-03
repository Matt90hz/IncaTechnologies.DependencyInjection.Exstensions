using System;

namespace IncaTechnologies.DependencyInjection.Exstensions.Attributes
{
    /// <summary>
    /// Mark a service to be reagisterd in dipendency incetion with a given impementation as singleton.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    public sealed class AddSingletonServiceAttribute : Attribute
    {
        /// <summary>
        /// The type of the concrete implementation of the service.
        /// </summary>
        public Type Implementation { get; }

        /// <summary>
        /// Create a new <see cref="AddSingletonAttribute"/>.
        /// </summary>
        /// <param name="implementation">The type of the concrete implementation of the service.</param>
        public AddSingletonServiceAttribute(Type implementation)
        {
            Implementation = implementation;
        }
    }

}

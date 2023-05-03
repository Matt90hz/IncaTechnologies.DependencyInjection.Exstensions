using System;

namespace IncaTechnologies.DependencyInjection.Exstensions.Attributes
{
    /// <summary>
    /// Mark a service to be reagisterd in dipendency incetion with a given impementation as transient.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    public sealed class AddTransientServiceAttribute : Attribute
    {
        /// <summary>
        /// The type of the concrete implementation of the service.
        /// </summary>
        public Type Implementation { get; }

        /// <summary>
        /// Create a new <see cref="AddTransientAttribute"/>.
        /// </summary>
        /// <param name="implementation">The type of the concrete implementation of the service.</param>
        public AddTransientServiceAttribute(Type implementation)
        {
            Implementation = implementation;
        }
    }

}

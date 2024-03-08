using System;
using System.Collections.Generic;
using System.Text;

namespace IncaTechnologies.DependencyInjection.Exstensions.Attributes
{
    /// <summary>
    /// Marking an object with an attribute and then call 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SpawnAttribute : Attribute { }
}

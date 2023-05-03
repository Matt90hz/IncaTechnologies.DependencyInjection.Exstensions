using IncaTechnologies.DependencyInjection.Exstensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    [AddSingletonService(typeof(AttributeSingletonService))]
    public interface IAttributeSingletonService
    {
        Guid Id { get; }
    }
}

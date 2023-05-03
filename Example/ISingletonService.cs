using IncaTechnologies.DependencyInjection.Exstensions.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public interface ISingletonService
    {
        Guid Id { get; }
    }

}

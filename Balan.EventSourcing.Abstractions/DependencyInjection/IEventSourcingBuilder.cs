using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balan.EventSourcing.Abstractions.DependencyInjection
{
    public interface IEventSourcingBuilder
    {
        IServiceCollection Services { get; }
    }
}
